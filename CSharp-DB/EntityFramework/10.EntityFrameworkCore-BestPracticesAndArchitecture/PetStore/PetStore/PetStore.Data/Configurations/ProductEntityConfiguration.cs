using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Common;
using PetStore.Models;

namespace PetStore.Data.Profiles
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasAlternateKey(x => x.Name);

            builder
                .Property(x => x.Name)
                .HasMaxLength(GlobalConstants.ProductNameMaxLength)
                .IsUnicode(true);
        }
    }
}
