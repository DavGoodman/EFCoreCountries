namespace EFCoreCountries.DTOs.PostDTOs
{
    public class LanguageCreationDTO
    {
        public string LanguageName { get; set; }
        //public List<int> CountryIds { get; set; }
        public List<CountryLanguageCreationForLDTO> CountriesLanguages { get; set; }
    }
}
