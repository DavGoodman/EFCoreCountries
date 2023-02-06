namespace EFCoreCountries.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int GovernmentId { get; set; }
        public Government Government { get; set; }
        public Leader Leader { get; set; }
        public List<CountryLanguage> CountriesLanguages { get; set; }
    }
}
