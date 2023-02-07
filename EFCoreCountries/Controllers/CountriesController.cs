
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreCountries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EFCoreCountries.Entities;
using EFCoreCountries.DTOs.GetDTOs;
using EFCoreCountries.DTOs.PostDTOs;
using EFCoreCountries.DTOs.PutDTOs;

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

        [HttpGet("CountryDetailsById/{id:int}")]
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

            context.Entry(country.Government).State = EntityState.Unchanged;

            context.Add(country);
            await context.SaveChangesAsync();
            return Ok(country);

        }



        [HttpGet("GetCountryUpdateTemplateByID/{id:int}")]
        public async Task<ActionResult> GetTemplate(int id)
        {
            var countryDB = await context.Countries
                .Include(c => c.CountriesLanguages)
                .Include(c => c.Leader)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (countryDB == null) return NotFound();

            return Ok(countryDB);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CountryUpdateDTO countryUpdateDto , int id)
        {
            var countryDB = await context.Countries
                .Include(c => c.CountriesLanguages)
                .Include(c => c.Leader)
                .Include(c => c.Government)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (countryDB == null) return NotFound();

            countryDB = mapper.Map(countryUpdateDto, countryDB);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var country = await context.Countries.FirstOrDefaultAsync(p => p.Id == id);

            if (country is null) return NotFound();

            context.Remove(country);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

