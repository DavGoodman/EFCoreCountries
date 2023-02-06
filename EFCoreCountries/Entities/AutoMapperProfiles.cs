using AutoMapper;
using EFCoreCountries.DTOs;

namespace EFCoreCountries.Entities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Language, LanguageDTO>()
                .ForMember(dto=>dto.Countries, ent=>ent.MapFrom(p=>p.CountriesLanguages.Select(cl=>cl.Country.Name)));

            CreateMap<Leader, LeaderDTO>();

            CreateMap<Country, CountryDTO>()
                .ForMember(dto => dto.Languages,
                    ent => ent.MapFrom(p => p.CountriesLanguages.Select(x => x.Language.LanguageName)))
                .ForMember(dto => dto.Leader, ent => ent.MapFrom(p => p.Leader))
                .ForMember(dto => dto.Government, ent => ent.MapFrom(p => p.Government));

            CreateMap<Government, GovernmentDTO>();



            CreateMap<CountryCreationDTO, Country>()
                .ForMember(ent=>ent.GovernmentId, dto=>dto.MapFrom(prop=>prop.GovernmentId));

            CreateMap<CountryLanguageCreationDTO, CountryLanguage>();

            CreateMap<LeaderCreationDTO, Leader>();

        }

    }
}
