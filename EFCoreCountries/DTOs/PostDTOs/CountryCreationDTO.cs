using EFCoreCountries.Entities;

namespace EFCoreCountries.DTOs.PostDTOs
{
    public class CountryCreationDTO
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int GovernmentId { get; set; }
        public LeaderCreationDTO Leader { get; set; }
        public List<CountryLanguageCreationForCDTO> CountriesLanguages { get; set; }
    }
}
