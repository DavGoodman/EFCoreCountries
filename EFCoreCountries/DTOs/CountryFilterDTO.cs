namespace EFCoreCountries.DTOs
{
    public class CountryFilterDTO
    {
        public string? Name { get; set; }
        public int? MinPopulation { get; set; }
        public string? Leader { get; set; }
        public string? Language { get; set; }
        public string? GovernmentType { get; set; }
    }
}
