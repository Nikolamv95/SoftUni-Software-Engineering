﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.Data.Profiles
{
    public class ClientProductEntityConfiguration : IEntityTypeConfiguration<ClientProduct>
    {
        public void Configure(EntityTypeBuilder<ClientProduct> builder)
        {
            builder.HasKey(ck => new {ck.ClientId, ck.ProductId});
        }
    }
}
