using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Models
{
    public class EcommContext : DbContext
    {
        public EcommContext()
        {
        }

        public EcommContext(DbContextOptions<EcommContext> options)
                             : base(options)
        {
        }

        public DbSet<EcommerceBrand>  EcommerceBrands { get; set; }
        public DbSet<Market>  Markets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0J5UCH7\\SQLEXPRESS;Database=EcommerceDB;Integrated Security=true;");
            }
        }
    }
}
