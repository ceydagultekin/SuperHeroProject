using AutoMapper;
using SuperHeroProject.Entities;
using SuperHeroProject.Entities.Dto;

namespace SuperHeroProject.Helper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<SuperHeroDto, SuperHero>();
            CreateMap<PlaceDto,Place>();
            CreateMap<Place, PlaceDto>();
            CreateMap<SuperHero, SuperHeroDto>();
        }
        
    }
}
