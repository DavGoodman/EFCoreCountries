﻿namespace EFCoreCountries.Entities
{
    public class CountryLanguage
    {
        public int CountryId { get; set; }
        public int LanguageId { get; set; }
        public Country Country { get; set; }
        public Language Language { get; set; }

    }
}
