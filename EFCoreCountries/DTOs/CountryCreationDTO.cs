using EFCoreCountries.Entities;

namespace EFCoreCountries.DTOs
{
    public class CountryCreationDTO
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int GovernmentId { get; set; }
        public LeaderCreationDTO Leader { get; set; }
        public List<CountryLanguageCreationDTO> CountriesLanguages { get; set; }
    }
}
