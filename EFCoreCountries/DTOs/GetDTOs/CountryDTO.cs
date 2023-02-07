using EFCoreCountries.Entities;

namespace EFCoreCountries.DTOs.GetDTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public LeaderDTO Leader { get; set; }
        public ICollection<string> Languages { get; set; }
        public GovernmentDTO Government { get; set; }
    }
}
