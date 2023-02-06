namespace EFCoreCountries.Entities
{
    public class Government
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string SystemDescription { get; set; }
        public List<Country> Countries { get; set; }


    }
}
