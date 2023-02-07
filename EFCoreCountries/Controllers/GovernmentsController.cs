using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreCountries.DTOs.GetDTOs;
using EFCoreCountries.DTOs.PostDTOs;
using EFCoreCountries.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCountries.Controllers
{
    [ApiController]
    [Route("api/governmentTypes")]
    public class GovernmentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GovernmentsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet("all")]
        public async Task<ActionResult> Get()
        {
            var government = await context.Governments
                .ProjectTo<GovernmentWithCNamesDTO>(mapper.ConfigurationProvider)
                .ToListAsync();


            if (government == null) return NotFound();

            return Ok(government);

        }

        [HttpGet("ById/{id:int}")]
        public async Task<ActionResult<GovernmentWithCNamesDTO>> Get(int id)
        {
            var Gov = await context.Governments
                .ProjectTo<GovernmentWithCNamesDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (Gov == null) return NotFound();

            return Gov;

        }

        // without DTO
        //[HttpGet]
        //public async Task<IEnumerable<Government>> Get()
        //{
        //    return await context.Governments
        //        .Select(g => new Government
        //            { SystemName = g.SystemName, SystemDescription = g.SystemDescription, Countries = g.Countries })
        //        .ToListAsync();
        //}


        [HttpPost]
        public async Task<ActionResult> Post(GovernmentCreationDTO countryCreationDto)
        {
            var gov = mapper.Map<Government>(countryCreationDto);

            context.Add(gov);
            await context.SaveChangesAsync();
            return Ok(gov);

        }

    }
}
