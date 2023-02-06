
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreCountries;
using EFCoreCountries.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EFCoreCountries.Entities;

namespace ESCoreMoviesDb.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public CountriesController(ApplicationDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {
            var country = await context.Countries
                .ProjectTo<CountryDTO>(mapper.ConfigurationProvider)
                .ToListAsync();


            if (country == null) return NotFound();

            return Ok(country);

        }

        [HttpGet("ById/{id:int}")]
        public async Task<ActionResult<CountryDTO>> Get(int id)
        {
            var country = await context.Countries
                .ProjectTo<CountryDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c=>c.Id == id);

            if (country == null) return NotFound();

            return country;

        }

        [HttpGet("Filtered")]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> Filter([FromQuery] CountryFilterDTO countryFilterDto)
        {
            var countriesQueryable = context.Countries.AsQueryable();

            if (countriesQueryable == null) return NotFound();

            if (!string.IsNullOrEmpty(countryFilterDto.Name))
            {
                countriesQueryable = countriesQueryable.Where(c => c.Name.Contains(countryFilterDto.Name));
            }

            if (countryFilterDto.MinPopulation != null)
            {
                countriesQueryable = countriesQueryable.Where(c => c.Population >= countryFilterDto.MinPopulation);
            }

            if (!string.IsNullOrEmpty(countryFilterDto.Leader))
            {
                countriesQueryable = countriesQueryable.Where(c => c.Leader.Name.Contains(countryFilterDto.Leader));
            }

            if (!string.IsNullOrEmpty(countryFilterDto.GovernmentType))
            {
                countriesQueryable = countriesQueryable.Where(c => c.Government.SystemName.Contains(countryFilterDto.GovernmentType));
            }

            if (!string.IsNullOrEmpty(countryFilterDto.Language))
            {
                countriesQueryable = countriesQueryable.Where(c=>c.CountriesLanguages.Select(cl=>cl.Language.LanguageName).Contains(countryFilterDto.Language));
            }

            var countries = await countriesQueryable
                .Include(c=>c.Leader)
                .Include(c=>c.Government)
                .Include(c=>c.CountriesLanguages)
                .ThenInclude(cl => cl.Language)
                .ToListAsync();

            return mapper.Map<List<CountryDTO>>(countries);
        }


        [HttpPost]
        public async Task<ActionResult> Post(CountryCreationDTO countryCreationDto)
        {
            var country = mapper.Map<Country>(countryCreationDto);

            //foreach (var Language in country.CountriesLanguages) context.Entry(Language).State = EntityState.Unchanged;
            context.Entry(country.GovernmentId).State = EntityState.Unchanged;

            context.Add(country);
            await context.SaveChangesAsync();
            return Ok(country);

        }
    }
}

//{
//    "name": "United Kingdom",
//    "population": 67330000,
//    "governmentId": 2,
//    "leader": {
//        "name": "Rishi Sunak",
//        "party": "Conservative Party"
//    },
//    "countriesLanguages": [
//    {
//        "languageId": 1
//    }
//    ]
//}