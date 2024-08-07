using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroProject.Interfaces;
using SuperHeroProject.Entities;
using Microsoft.EntityFrameworkCore;
using SuperHeroProject.Entities.Dto;
using SuperHeroProject.Repositories;


namespace SuperHeroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlace _placerepository;

        public PlaceController(IPlace placerepository)
        {
            _placerepository = placerepository;
        }

        [HttpGet("all",Name = "GetPlaces")]
        public async Task<ActionResult> GetPlaces()
        {
            try
            {
                var places = await _placerepository.GetPlaces();
                return Ok(places);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("api/places/{id}", Name ="GetPlaceById")]
        public async Task<ActionResult<Place>> GetPlaceById([FromQuery] int placeid)
        {
            try
            {
                var place = await _placerepository.GetPlaceById(placeid);
                if (place == null)
                    return NotFound();
                return Ok(place);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }    
        }

        [HttpPost(Name ="AddPlace")]
        public async Task<ActionResult<PlaceDto>> AddPlace(PlaceDto placeDto)
        {
            try
            {
               var addedplace= await _placerepository.AddPlace(placeDto);
                return Ok(addedplace);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("api/places/superhero/{id}")]
        public async Task<ActionResult<Place>> GetSuperHeroWithPlace(int id)
        {
            try
            {
               var searchedplace= await _placerepository.GetSuperHeroWithPlace(id);
                return Ok(searchedplace);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }

        [HttpDelete(Name ="DeletePlace")]
        public async Task<ActionResult<Place>> DeletePlace([FromQuery] int placeid)
        {
            try
            {
                await _placerepository.DeletePlace(placeid);
                return Ok($"{placeid} id numaralı place silinmiştir.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut(Name ="UpdatePlace")]
        public async Task<ActionResult<Place>> UpdatePlace([FromBody] PlaceDto placeDto)
        {
            try
            {
                var updatedplace = await _placerepository.UpdatePlace(placeDto);
                return Ok(updatedplace);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
