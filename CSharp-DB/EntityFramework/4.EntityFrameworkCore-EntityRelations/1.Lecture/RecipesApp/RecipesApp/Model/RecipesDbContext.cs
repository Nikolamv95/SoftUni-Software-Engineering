using Microsoft.EntityFrameworkCore;

namespace RecipesApp.Model
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {
        }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=RecipesApp;Integrated Security=true;");
            }
        }

        //Here we can make additional settings for our classes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This code makes Id primary key and setyp the Column name with different settings.
            modelBuilder.Entity<Recipe>(entity =>
            {
                //This makes Id column primary key
                entity.HasKey(x => x.Id);

                //This makes both columns from Reciper composite key
                entity.HasKey(x => new { x.Id, x.Name });

                //This gives the oportunity to search in Recipe.Name by index
                entity.HasIndex(x => x.Name);

                //This code will create EGN column in Recipes Database but it 
                //will not be visible in our C# classes
                entity.Property<string>("EGN").HasColumnType("nvarchar(10)");

                //This code will make the maximum data length of Recipe.Name varchar(50)
                //This code can be inside this scope, it`s our descision
                modelBuilder.Entity<Recipe>()
                            .Property(x => x.Name)
                            .HasColumnName("Tittle")
                            .HasMaxLength(30)
                            .IsUnicode(true)
                            .IsRequired();
            });


            //This code makes the property description required NOT NULL
            modelBuilder.Entity<Recipe>()
                        .Property(x => x.Descriptiom)
                        .IsRequired();

            //This code will create table MyRecipes instead Recipes which is on default
            //and will change the Coulmn Name -> Name to Tittle
            modelBuilder.Entity<Recipe>()
                        .ToTable("MyRecipes", "system")
                        .Property(x => x.Name)
                        .HasColumnName("Tittle");

        }
    }
}
