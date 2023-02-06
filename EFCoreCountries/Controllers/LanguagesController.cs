using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreCountries.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCountries.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class LanguagesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public LanguagesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("byLanguageName")]
        public async Task<ActionResult> Get(string? name)
        {
            var languages = await context.Languages.ProjectTo<LanguageDTO>(mapper.ConfigurationProvider)
                .Where(l=>l.LanguageName.Contains(name))
                .ToListAsync();
            
            if (languages == null) return NotFound();

            return Ok(languages);
        }

    }
}
