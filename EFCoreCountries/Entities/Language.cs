namespace EFCoreCountries.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }

        public List<CountryLanguage> CountriesLanguages { get; set; }
    }
}