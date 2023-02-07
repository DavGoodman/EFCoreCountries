using AutoMapper;
using EFCoreCountries.DTOs.GetDTOs;
using EFCoreCountries.DTOs.PostDTOs;
using EFCoreCountries.DTOs.PutDTOs;

namespace EFCoreCountries.Entities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Get DTOs
            CreateMap<Language, LanguageDTO>()
                .ForMember(dto=>dto.Countries, ent=>ent.MapFrom(p=>p.CountriesLanguages.Select(cl=>cl.Country.Name)));

            CreateMap<Leader, LeaderDTO>();

            CreateMap<Country, CountryDTO>()
                .ForMember(dto => dto.Languages,
                    ent => ent.MapFrom(p => p.CountriesLanguages.Select(x => x.Language.LanguageName)))
                .ForMember(dto => dto.Leader, ent => ent.MapFrom(p => p.Leader))
                .ForMember(dto => dto.Government, ent => ent.MapFrom(p => p.Government));

            CreateMap<Government, GovernmentDTO>();


            CreateMap<Government, GovernmentWithCNamesDTO>()
                .ForMember(dto => dto.Countries, ent=>ent.MapFrom(p=>p.Countries.Select(c=>c.Name)));
            



            // CREATION DTOs
            CreateMap<CountryCreationDTO, Country>()
                .ForMember(ent=>ent.Government, dto=>dto.MapFrom(prop => new Government(){Id = prop.GovernmentId}));
            //
            CreateMap<CountryLanguageCreationForCDTO, CountryLanguage>();

            CreateMap<LeaderCreationDTO, Leader>();

            CreateMap<LanguageCreationDTO, Language>();
                //.ForMember(ent=>ent.CountriesLanguages.Select(p=>p.CountryId), dto=>dto.MapFrom(p=>p.CountryIds.Select(id => id)));
            
            CreateMap<CountryLanguageCreationForLDTO, CountryLanguage>();

            CreateMap<GovernmentCreationDTO, Government>();



            // Update DTOs
            CreateMap<CountryUpdateDTO, Country>();

            CreateMap<LeaderUpdateDTO, Leader>();

        }
    }
}
