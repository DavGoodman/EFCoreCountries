using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCountries.Entities.Configurations
{
    public class LeaderConfig : IEntityTypeConfiguration<Leader>
    {
        public void Configure(EntityTypeBuilder<Leader> builder)
        {


            builder.HasOne(p => p.Country)
                .WithOne(c => c.Leader)
                .HasForeignKey<Leader>(p => p.CountryId);

        }
    
    }
}
