namespace EFCoreCountries.Entities
{
    public class Leader
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
       
        //public Country Country { get; set; } // optional
        
    }
}