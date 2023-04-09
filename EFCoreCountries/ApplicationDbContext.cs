using System.Reflection;
using EFCoreCountries.Entities;
using EFCoreCountries.Entities.Seeding;
using Microsoft.EntityFrameworkCore;


namespace EFCoreCountries
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //modelBuilder.Entity<Country>()                
            //    .HasOne(c => c.Leader)
            //    .WithOne()
            //    .HasForeignKey<Leader>(l => l.CountryId)
            //    .OnDelete(DeleteBehavior.SetNull);


            InitialSeed.Seed(modelBuilder);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<CountryLanguage> CountriesLanguages { get; set; }

    }
}
