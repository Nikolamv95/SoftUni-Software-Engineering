﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Common;
using PetStore.Models;

namespace PetStore.Data.Profiles
{
    public class BreedEntityConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder
                .Property(b => b.Name)
                .HasMaxLength(GlobalConstants.BreedMaxLength)
                .IsUnicode();
        }
    }
}
