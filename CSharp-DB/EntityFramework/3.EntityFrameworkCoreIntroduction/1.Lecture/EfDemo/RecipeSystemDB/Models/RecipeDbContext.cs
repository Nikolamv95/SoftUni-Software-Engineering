using Microsoft.EntityFrameworkCore;

namespace NewRecipeSystem.Models
{
    public class RecepiesDbContext : DbContext
    {
        public RecepiesDbContext()
        {
        }

        public RecepiesDbContext(DbContextOptions<RecepiesDbContext> options) 
                : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0J5UCH7\\SQLEXPRESS;Database=RecepiesDBNew;Integrated Security=true;");
            }
        }
    }
}
