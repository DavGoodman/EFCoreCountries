using EFCoreCountries.DTOs.PostDTOs;

namespace EFCoreCountries.DTOs.PutDTOs
{
    public class CountryUpdateDTO
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int GovernmentId { get; set; }
        public LeaderUpdateDTO Leader { get; set; }
        public List<CountryLanguageCreationForCDTO> CountriesLanguages { get; set; }
    }
}
