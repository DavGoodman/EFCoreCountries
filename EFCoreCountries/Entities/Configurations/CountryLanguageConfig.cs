using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCountries.Entities.Configurations
{
    public class CountryLanguageConfig : IEntityTypeConfiguration<CountryLanguage>
    {
        public void Configure(EntityTypeBuilder<CountryLanguage> builder)
        {
            builder.HasKey(x => new{ x.CountryId, x.LanguageId});
        }
    }
}
