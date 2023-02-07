using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCountries.Entities.Configurations
{
    public class GovernmentConfig : IEntityTypeConfiguration<Government>
    {
        public void Configure(EntityTypeBuilder<Government> builder)
        {
            builder.HasIndex(x => x.SystemName).IsUnique();
            builder.Property(s=>s.SystemName).IsRequired();

            builder.Property(s=>s.SystemDescription).HasColumnType("varchar(max)");
        }
    }
}
