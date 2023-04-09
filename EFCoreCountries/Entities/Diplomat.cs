using Microsoft.Build.Framework;

namespace EFCoreCountries.Entities
{
    public class Diplomat : Person
    {

        public int HostCountryId { get; set; }
        public Country HostCountry { get; set; }
    }
}
