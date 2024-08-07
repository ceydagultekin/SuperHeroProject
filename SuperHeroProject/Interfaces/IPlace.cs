using SuperHeroProject.Entities;
using SuperHeroProject.Entities.Dto;

namespace SuperHeroProject.Interfaces
{
    public interface IPlace
    {
        Task<IEnumerable<Place>> GetPlaces();
        Task<Place> GetPlaceById(int id);
        Task<PlaceDto> AddPlace(PlaceDto placeDto);
        Task<Place> GetSuperHeroWithPlace(int id);
        Task DeletePlace(int id);
        Task<Place> UpdatePlace(PlaceDto placeDto);
        
    }
}
