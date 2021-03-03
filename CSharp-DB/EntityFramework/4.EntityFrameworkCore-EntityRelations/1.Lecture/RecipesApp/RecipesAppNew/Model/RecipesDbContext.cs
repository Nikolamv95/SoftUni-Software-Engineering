using Microsoft.EntityFrameworkCore;

namespace RecipesApp.Model
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {
        }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            :base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=RecipesAppNew;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
