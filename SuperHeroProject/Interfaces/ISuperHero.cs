using SuperHeroProject.Entities;
using SuperHeroProject.Entities.Dto;

namespace SuperHeroProject.Interfaces
{
    public interface ISuperHero
    {
        Task<IEnumerable<SuperHero>> GetSuperHeroes();
        Task<SuperHero> GetSuperHero(int id);
        Task DeleteSuperHero(int id);
        Task<SuperHero> AddSuperHero(SuperHeroDto heroDto);
        Task<SuperHero> UpdateSuperHero(SuperHeroDto heroDto);
        Task<IEnumerable<SuperHero>> GetPlaceWithSuperHeroes(int id);
    }
}
