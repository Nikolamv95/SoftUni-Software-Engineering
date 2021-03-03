using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{   
    //Our DbSet class acts like an ICollection<T>, 
    public class DbSet<TEntity> : ICollection<TEntity>
            where TEntity : class, new()
    {
        //Constructors
        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();
            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        //Properties
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        internal IList<TEntity> Entities { get; set; }

        public int Count => this.Entities.Count();
        public bool IsReadOnly => this.Entities.IsReadOnly;

        /// <summary>
        /// Adding entities in the database.
        /// We add our item both in the entities property, and the change tracker.
        /// </summary>
        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            this.Entities.Add(item);
            this.ChangeTracker.Add(item);
        }

        /// <summary>
        /// Removes all entities, by using the Remove method. 
        /// We can also let the change tracker know, that all the entities were removed.
        /// </summary>
        public void Clear()
        {
            while (this.Entities.Any())
            {
                var entity = this.Entities.First();
                this.Remove(entity); //We reuse the "public bool Remove(TEntity item) method"
            }
        }

        /// <summary>
        /// Checks if our entities contain a particular entity.
        /// </summary>
        /// <returns></returns>
        public bool Contains(TEntity item) 
                                => this.Entities.Contains(item);

        /// <summary>
        /// The CopyTo method copies our entities to an array of type T, starting at a particular array index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TEntity[] array, int arrayIndex) 
                                => this.Entities.CopyTo(array, arrayIndex);

        /// <summary>
        /// Removes entity from entities and change tracker as well, only if the entity exist.
        /// </summary>
        /// <param name="item">Entity to remove</param>
        /// <returns></returns>
        public bool Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            bool removedSuccessfully = this.Entities.Remove(item);

            if (removedSuccessfully)
            {
                this.ChangeTracker.Remove(item);
            }

            return removedSuccessfully;
        }

        /// <summary>
        /// Remove a range of entities
        /// </summary>
        /// <param name="entities">Collection of entities to be remove</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity); //We reuse the "public bool Remove(TEntity item) method"
            }
        }

        /// <summary>
        /// Iterate trough the collection IList<TEntity> Entities
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TEntity> GetEnumerator()
        {
            return this.Entities.GetEnumerator();
        }

        /// <summary>
        /// Returns Get.Enumerator() method
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    
}