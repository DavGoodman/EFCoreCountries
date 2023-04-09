namespace EFCoreCountries.Entities
{
    public abstract class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public PersonType PersonType { get; set; }
    }
}
