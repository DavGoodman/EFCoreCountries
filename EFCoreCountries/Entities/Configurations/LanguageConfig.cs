using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCountries.Entities.Configurations
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasIndex(x => x.LanguageName).IsUnique();
            builder.Property(p=>p.LanguageName).IsRequired();
        }
    }
}
