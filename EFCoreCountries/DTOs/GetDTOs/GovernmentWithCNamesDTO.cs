namespace EFCoreCountries.DTOs.GetDTOs
{
    public class GovernmentWithCNamesDTO
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string SystemDescription { get; set; }
        public List<string> Countries { get; set; }

    }
}