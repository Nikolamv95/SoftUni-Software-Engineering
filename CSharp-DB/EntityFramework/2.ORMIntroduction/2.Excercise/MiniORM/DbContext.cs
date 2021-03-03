using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniORM
{
    public abstract class DbContext
    {
        //Fields
        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime)
        };

        //Constructor
        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);
            this.dbSetProperties = this.DiscoverDbSet();

            using (new ConnectionManager(connection))
            {
                this.InitializeDbSet();
            }

            //Navigational Property
            this.MapAllRelations();
        }

        //Methods
        public void SaveChanges()
        {
            //We need to declare an array of our actual DB sets as collections
            var dbSets = this.dbSetProperties
                           .Select(pi => pi.Value.GetValue(this))
                           .ToArray();

            //We need to ensure each entity in the context is valid
            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                           .Where(entity => !IsObjectValid(entity)).ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException
                            ($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
                }
            }

            //We need using block, which will open a connection to our database
            using (new ConnectionManager(connection))
            {
                //We need to create another using block – this time for starting a database transaction
                using (SqlTransaction transaction = this.connection.StartTransaction())
                {
                    //We need to find the entity type of each DbSet
                    foreach (IEnumerable dbset in dbSets)
                    {
                        Type dbSetType = dbset.GetType().GetGenericArguments().First();

                        MethodInfo persistMethod = typeof(DbContext)
                                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbset });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException ioe)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        private bool IsObjectValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationErrors = new List<ValidationResult>();

            var validationResults = Validator.TryValidateObject
                                    (entity, validationContext, validationErrors, validateAllProperties: true);

            return validationResults;
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            //Save our current table name (string) 
            string tableName = GetTableName(typeof(TEntity));

            //Collect our columns by calling the FetchColumnNames() method
            string[] columns = this.connection.FetchColumnNames(tableName).ToArray();

            //Check the dbSet’s ChangeTracker for any added entities, 
            //and if there are any, we use the InsertEntities()
            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            //We need our modified entities and if there are any modified entities, we update our database 
            IEnumerable<TEntity> modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            //We check if there are any removed entities. If we have any, we delete them from our database too.
            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }

        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
                where TEntity : class
        {
            var table = typeof(TEntity);

            string[] columns = GetEntityColumnNames(table);

            var tableName = GetTableName(table);

            var fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();

            return fetchedRows;
        }

        //Returns an array of strings with the column names and accepts the table type as a parameter. 
        private string[] GetEntityColumnNames(Type table)
        {
            var tableName = this.GetTableName(table);
            var dbColumns = this.connection.FetchColumnNames(tableName);

            string[] columns = table
                            .GetProperties()
                            .Where(pi => dbColumns.Contains(pi.Name) &&
                                !pi.HasAttribute<NotMappedAttribute>() &&
                                AllowedSqlTypes.Contains(pi.PropertyType))
                            .Select(pi => pi.Name)
                            .ToArray();

            return columns;
        }

        //Returns a string tableName and gets the tableType as a parameter
        private string GetTableName(Type tableType)
        {
            var tableName = ((TableAttribute)Attribute.GetCustomAttribute(tableType, typeof(TableAttribute)))?.Name;

            if (tableName == null)
            {
                tableName = this.dbSetProperties[tableType].Name;
            }

            return tableName;
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new() where TCollection : class, new()
        {

            //Now, we need to get the primary and the foreign keys. The primary ones we find by getting all the properties 
            //which have a [Key] attribute in the collectionType variable we declared before. We can get the foreign key 
            //in the same way but using the entityType variable.
            Type entityType = typeof(TDbSet);
            Type collectionType = typeof(TCollection);

            PropertyInfo[] primaryKeys = collectionType.GetProperties()
                              .Where(pi => pi.HasAttribute<KeyAttribute>())
                              .ToArray();

            PropertyInfo primaryKey = primaryKeys.First();
            PropertyInfo foreignKey = entityType.GetProperties()
                                .First(pi => pi.HasAttribute<KeyAttribute>());

            //We check if we are dealing with a M-M relation, which is only true if we have 2 or more primary keys. 
            //If we have a M-M relation, we can get the foreign key by finding the first type property, 
            //whose name is equal to the foreign key attribute’s name and has the same property type as the entity type.

            bool isManyToMany = primaryKeys.Length >= 2;
            if (isManyToMany)
            {
                primaryKey = collectionType.GetProperties()
                          .First(pi => collectionType.GetProperty
                            (pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                            .PropertyType == entityType);
            }

            //Now we get the collection’s DB set, which we will filter with a where clause and extract all of the entities
            //whose foreign keys are equal to the primary key of the current entity.
            //Finally, call the ReflectionHelper.ReplaceBackingField() method and we replace the 
            //null collection with a populated collection.

            DbSet<TCollection> navigationDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this);

            foreach (var entity in dbSet)
            {
                object primaryKeyValue = foreignKey
                                        .GetValue(entity);

                TCollection[] navigationEntities = navigationDbSet
                                        .Where(navigationEntity => primaryKey
                                            .GetValue(navigationEntity)
                                            .Equals(primaryKeyValue))
                                        .ToArray();
            }


        }

        //This method maps all of the relations of the DB set
        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            //There are two types of relations: Foreign key properties, which map many-to-one relations, and collections, 
            //which map one-to-many and many-to-many relations. First, we map the navigation properties (Town town exmp..) 
            //and then we map the collections. In order to discover what collections our TEntity has, we need to reflect 
            //the class and find every property, which is of type ICollection<>

            Type entityType = typeof(TEntity);

            this.MapNavigationProperties(dbSet);

            PropertyInfo[] collections = entityType
                                .GetProperties()
                                .Where(pi => pi.PropertyType.IsGenericType &&
                                    pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)).ToArray();


            foreach (PropertyInfo collection in collections)
            {
                Type collectionType = collection.PropertyType.GenericTypeArguments.First();
                MethodInfo mapCollectionMethod = typeof(DbContext)
                            .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(entityType, collectionType);

                mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }

        }

        //Accepts a DB set as a parameter. This method finds the entity’s foreign keys (there could be multiple) and iterates
        //over them. For each of those foreign keys, we discover what navigation property they point to and its type. Then, we
        //use this type to get the other side of the relation’s DB set. Then, for each entity in that DB set, we find the first
        //entity, whose primary key value is equal to the foreign key value in our TEntity. 
        //Finally, we replace the navigation property’s value (which is currently null) with the entity we found.
        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);

            PropertyInfo[] foreignKeys = entityType.GetProperties()
                                         .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                                         .ToArray();

            foreach (var foreignKey in foreignKeys)
            {
                string navigationPropertyName = foreignKey
                                                    .GetCustomAttribute<ForeignKeyAttribute>().Name;

                PropertyInfo navigationProperty = entityType
                                                    .GetProperty(navigationPropertyName);

                object navigationDbSet = this.dbSetProperties[navigationProperty.PropertyType]
                                            .GetValue(this);

                PropertyInfo navigationPrimaryKey = navigationProperty
                                                    .PropertyType
                                                    .GetProperties()
                                                    .First(pi => pi.HasAttribute<KeyAttribute>());

                foreach (var entity in dbSet)
                {
                    object foreignKeyValue = foreignKey.GetValue(entity);

                    object navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
                                                    .First(currentNavigationProperty =>
                                                        navigationPrimaryKey.GetValue(currentNavigationProperty)
                                                        .Equals(foreignKeyValue));

                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private void MapAllRelations()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetProperty in this.dbSetProperties)
            {
                Type dbSetType = dbSetProperty.Key;

                MethodInfo mapRelationsGeneric = typeof(DbContext)
                                            .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                                            .MakeGenericMethod(dbSetType);

                object dbSet = dbSetProperty.Value.GetValue(this);

                mapRelationsGeneric.Invoke(this, new object[] { dbSet });
            }
        }

        //For each DB set, we will invoke the PopulateDbSet(dbSetProperty) method dynamically, 
        //because we are providing the generic type parameter at runtime, since we don’t know what the framework user’s DB sets are.
        private void InitializeDbSet()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSet in this.dbSetProperties)
            {
                Type dbSetType = dbSet.Key;
                PropertyInfo dbSetProperty = dbSet.Value;

                MethodInfo populateDbSetGeneric = typeof(DbContext)
                                           .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                                           .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        //We need to replace the actual DbSet property in the current DbContext instance. Since the Db sets don’t have a setter, 
        //we need to replace its backing field, by using the ReflectionHelper.ReplaceBackingField() method
        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> entities = LoadTableEntities<TEntity>();

            DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(entities);
            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSet()
        {
           Dictionary<Type,PropertyInfo> dbSets = this.GetType()
                                        .GetProperties()
                                        .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                                        .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

            return dbSets;
        }
    }
}