using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCountries.Entities.Configurations
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasDiscriminator(p => p.PersonType)
                .HasValue<Leader>(PersonType.Leader)
                .HasValue<Diplomat>(PersonType.Diplomat);
        }
    }
}
