using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Common;
using PetStore.Models;

namespace PetStore.Data.Profiles
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(x => x.Town)
                .HasMaxLength(GlobalConstants.TownNameMaxLength)
                .IsUnicode(true);

            builder
                .Property(x => x.Address)
                .HasMaxLength(GlobalConstants.AddressNameMAxLength)
                .IsUnicode(true);

            builder
                .Ignore(x => x.TotalPrice);
        }
    }
}
