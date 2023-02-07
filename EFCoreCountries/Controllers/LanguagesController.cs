using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreCountries.DTOs.GetDTOs;
using EFCoreCountries.DTOs.PostDTOs;
using EFCoreCountries.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace EFCoreCountries.Controllers
{
    [ApiController]
    [Route("api/languages")]
    public class LanguagesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public LanguagesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<ActionResult> Get()
        {
            var languages = await context.Languages.ProjectTo<LanguageDTO>(mapper.ConfigurationProvider).ToListAsync();

            if (languages == null) return NotFound();

            return Ok(languages);
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


        [HttpPost]
        public async Task<ActionResult> Post(LanguageCreationDTO languageCreationDto)
        {
            var language = mapper.Map<Language>(languageCreationDto);

            context.Add(language);
            await context.SaveChangesAsync();
            return Ok(language);
        }

    }
}
