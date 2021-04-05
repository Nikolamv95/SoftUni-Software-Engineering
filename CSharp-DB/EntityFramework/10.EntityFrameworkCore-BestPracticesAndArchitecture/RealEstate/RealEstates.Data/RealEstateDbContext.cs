using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RealEstates.Models;

namespace RealEstates.Data
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext()
        {
        }
        public RealEstateDbContext(DbContextOptions options) 
            : base(options)
        {
        }


        public DbSet<RealEstateProperty> RealEstateProperties { get; set; }
        public DbSet<RealEstatePropertyTag> RealEstatePropertyTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=DESKTOP-ASP7MDT;Database=RealEstate;Integrated Security=true");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>()
                .HasMany(x => x.RealEstateProperties)
                .WithOne(x => x.District)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RealEstatePropertyTag>().HasKey(x=> new { x.RealEstatePropertyId, x.TagId});
        }
    }
}
