using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroProject.Data;
using SuperHeroProject.Entities;
using SuperHeroProject.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperHeroProject.Entities.Dto;

namespace SuperHeroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SuperHeroController : ControllerBase      
    {
        private readonly ISuperHero _superherorepository;
        private readonly ILogger<SuperHeroController> _logger;

        public SuperHeroController(ISuperHero superherorepository, ILogger<SuperHeroController> logger)
        {
            _superherorepository = superherorepository;
            _logger = logger;
        }

        [HttpGet(Name="GetHeroes")]
        public async Task<ActionResult> GetSuperHeroes()
        {
            try
            {
                var heroes = await _superherorepository.GetSuperHeroes();
                return Ok(heroes);
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero([FromQuery] int heroid)
        {
            try
            {
                var hero = await _superherorepository.GetSuperHero(heroid);
                if (hero == null)
                    return NotFound();
                return Ok(hero);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }                   
        }

        [HttpPost(Name ="AddSuperHero")]
        public async Task<ActionResult<SuperHero>> AddSuperHero([FromBody] SuperHeroDto heroDto)
        {
            try
            {
                var addedhero= await _superherorepository.AddSuperHero(heroDto);
                return Ok(addedhero);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the entity changes.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut(Name ="UpdateSuperHero")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero([FromBody] SuperHeroDto heroDto)
        {
            try
            {
                var updatedhero = await _superherorepository.UpdateSuperHero(heroDto);
                return Ok(updatedhero);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete(Name ="DeleteSuperHero")]
        public async Task<ActionResult> DeleteSuperHero([FromQuery] int heroid)
        {
            try
            {
                await _superherorepository.DeleteSuperHero(heroid);
                return Ok($"{heroid} id numaralı super silinmiştir.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}/superheroes")]
        public async Task<ActionResult<IEnumerable<SuperHero>>> GetPlaceWithSuperHeroes(int id)
        {
            try
            {
               var superheroes= await _superherorepository.GetPlaceWithSuperHeroes(id);
                return Ok(superheroes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
