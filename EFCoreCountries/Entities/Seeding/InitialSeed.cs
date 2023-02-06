using Microsoft.EntityFrameworkCore;

namespace EFCoreCountries.Entities.Seeding
{
    public class InitialSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            var presidentialRepublic = new Government { Id = 1, SystemName = "Presidential Republic", SystemDescription = "A presidential system, or single executive system, is a form of government in which a head of government, typically with the title of president, leads an executive branch that is separate from the legislative branch in systems that use separation of powers." };
            var parliamentaryRepublic = new Government { Id = 2, SystemName = "Parliamentary Republic", SystemDescription = "A parliamentary republic is a republic that operates under a parliamentary system of government where the executive branch derives its legitimacy from and is accountable to the legislature." };
            var absoluteMonarchy = new Government { Id = 3, SystemName = "Absolute Monarchy", SystemDescription = "Absolute monarchy is a form of monarchy in which the monarch rules in their own right or power. In an absolute monarchy, the king or queen is by no means limited and has absolute power." };
            var constitutionalMonarchy = new Government { Id = 4, SystemName = "Constitutional Monarchy", SystemDescription = "A constitutional monarchy, parliamentary monarchy, or democratic monarchy is a form of monarchy in which the monarch exercises their authority in accordance with a constitution and is not alone in decision making." };
            var onePartyState = new Government { Id = 5, SystemName = "One Party State", SystemDescription = "A one-party state, single-party state, one-party system,de-facto one-party state or single-party system is a type of sovereign state in which only one political party has the right to form the government, usually based on the existing constitution." };

            modelBuilder.Entity<Government>().HasData(presidentialRepublic, parliamentaryRepublic, absoluteMonarchy,
                constitutionalMonarchy, onePartyState);


            var norway = new Country { Id = 1, Name = "Norway", Population = 5_400_000, GovernmentId = constitutionalMonarchy.Id};
            var iceland = new Country { Id = 2, Name = "Iceland", Population = 370_000, GovernmentId = parliamentaryRepublic.Id};
            var hungary = new Country { Id = 3, Name = "Hungary", Population = 9_700_000, GovernmentId = parliamentaryRepublic.Id};
            var china = new Country { Id = 4, Name = "China", Population = 1_412_400_000, GovernmentId = onePartyState.Id};
            var usa = new Country { Id = 5, Name = "USA", Population = 332_000_000, GovernmentId = presidentialRepublic.Id};

            modelBuilder.Entity<Country>().HasData(norway, iceland, hungary, china, usa);


            var xiJinping = new Leader { Id = 1, Name = "Xi Jinping", CountryId = china.Id, Party = "Chinese Communist Party"};
            var jonasGahrStøre = new Leader { Id = 2, Name = "Jonas Gahr Støre", CountryId = norway.Id, Party = "Labour Party"};
            var katrinJakobsdottir = new Leader { Id = 3, Name = "Katrín Jakobsdóttir", CountryId = iceland.Id, Party = "Left Green"};
            var joeBiden = new Leader { Id = 4, Name = "Joe Biden", CountryId = usa.Id, Party = "Democratic Party"};
            var orbanViktor = new Leader { Id = 5, Name = "Orban Viktor", CountryId = hungary.Id, Party = "Fidesz"};

            modelBuilder.Entity<Leader>().HasData(xiJinping, jonasGahrStøre, katrinJakobsdottir, joeBiden, orbanViktor);

            var english = new Language { Id = 1, LanguageName = "English"};
            var norwegian = new Language { Id = 2, LanguageName = "Norwegian"};
            var icelandic = new Language { Id = 3, LanguageName = "Icelandic"};
            var sami = new Language { Id = 4, LanguageName = "Sami"};
            var mandarin = new Language { Id = 5, LanguageName = "Mandarin"};
            var hungarian = new Language { Id = 6, LanguageName = "Hungarian"};
            var cantonese = new Language { Id = 7, LanguageName = "Cantonese"};

            modelBuilder.Entity<Language>()
                .HasData(english, norwegian, icelandic, sami, mandarin, hungarian, cantonese);


            var icelandIcelandic = new CountryLanguage { CountryId = iceland.Id, LanguageId = icelandic.Id };
            var norwayNorwegian = new CountryLanguage { CountryId = norway.Id, LanguageId = norwegian.Id };
            var norwaySami = new CountryLanguage { CountryId = norway.Id, LanguageId = sami.Id };
            var hungaryHungarian = new CountryLanguage { CountryId = hungary.Id, LanguageId = hungarian.Id };
            var usaEnglish = new CountryLanguage { CountryId = usa.Id, LanguageId = english.Id };
            var chinaMandarin = new CountryLanguage { CountryId = china.Id , LanguageId = mandarin.Id };
            var chinaCantonese = new CountryLanguage { CountryId = china.Id , LanguageId = cantonese.Id };


            modelBuilder.Entity<CountryLanguage>().HasData(icelandIcelandic, norwayNorwegian, norwaySami,
                hungaryHungarian, usaEnglish, chinaMandarin, chinaCantonese);



        }   
    }
}
