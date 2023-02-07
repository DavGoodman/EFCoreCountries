using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCountries.Entities.Configurations
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique(true);
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
