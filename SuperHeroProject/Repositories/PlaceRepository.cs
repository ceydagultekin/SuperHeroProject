using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SuperHeroProject.Data;
using SuperHeroProject.Entities;
using SuperHeroProject.Entities.Dto;
using SuperHeroProject.Interfaces;
using FluentValidation;

namespace SuperHeroProject.Repositories
{
    public class PlaceRepository : IPlace
    {
        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IValidator<PlaceDto> _placeValidator;

        public PlaceRepository(DataContext dbcontext, IMapper mapper,IValidator<PlaceDto> validator)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _placeValidator = validator;
        }
        public async Task<IEnumerable<Place>> GetPlaces()
        {
            return await _dbcontext.Places.ToListAsync();
        }

        public async Task<Place> GetPlaceById(int id)
        {
            return await _dbcontext.Places.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PlaceDto> AddPlace(PlaceDto placeDto)
        {
            var validationResult = await _placeValidator.ValidateAsync(placeDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var place = _mapper.Map<Place>(placeDto); // PlaceDto'yu Place entity'sine dönüştürdük kaydetmek için
            await _dbcontext.Places.AddAsync(place); 
            await _dbcontext.SaveChangesAsync();

            return _mapper.Map<PlaceDto>(place); // Place entity'sini tekrar PlaceDto'ya dönüştürdük geri döndürmek için
        }
        public async Task<Place> GetSuperHeroWithPlace(int id)
        {
            var superheroWithPlace = await _dbcontext.SuperHeroes
                .Where(sh => sh.Id == id)
                .Select(sh => sh.Place) // SuperHero'nun Place nesnesini doğrudan seçiyoruz
                .FirstOrDefaultAsync();
            return superheroWithPlace;
        }
        public async Task DeletePlace(int id)
        {

            var place = await _dbcontext.Places.FirstOrDefaultAsync(x => x.Id==id);
            if (place is null)
            {
                throw new InvalidOperationException("Böyle bir place yok.");
            }
            _dbcontext.Remove(place);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Place> UpdatePlace(PlaceDto placeDto)
        {
            if (placeDto is null)
                throw new InvalidOperationException("Böyle bir place yok."); // put ve postta dto kullandım . Dto yu güncelledim unutma 

            var updatedplace = _mapper.Map<Place>(placeDto);
            _dbcontext.Places.Update(updatedplace);
            await _dbcontext.SaveChangesAsync();

            return (updatedplace);
        }

    }
}
