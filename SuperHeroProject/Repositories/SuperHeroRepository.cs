using SuperHeroProject.Interfaces;
using SuperHeroProject.Data;
using AutoMapper;
using SuperHeroProject.Entities;
using Microsoft.EntityFrameworkCore;
using SuperHeroProject.Entities.Dto;
using FluentValidation;

namespace SuperHeroProject.Repositories
{
    public class SuperHeroRepository:ISuperHero
    {
        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IValidator<SuperHeroDto> _superheroValidator;
        public SuperHeroRepository(DataContext context,IMapper mapper,IValidator<SuperHeroDto> validator)
        {
            _dbcontext = context;
            _mapper = mapper;
            _superheroValidator= validator;
        }
        public async Task<IEnumerable<SuperHero>> GetSuperHeroes()
        {
            return await _dbcontext.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero> GetSuperHero(int id)
        {
            return await _dbcontext.SuperHeroes.FirstOrDefaultAsync(_dbcontext => _dbcontext.Id == id);
        }

        public async Task DeleteSuperHero(int id)
        {
            var hero = await _dbcontext.SuperHeroes.FirstOrDefaultAsync(x => x.Id == id);
            if (hero is null)
            {
                throw new InvalidOperationException("Böyle bir hero yok.");
            }
                
            _dbcontext.Remove(hero);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<SuperHero> AddSuperHero(SuperHeroDto heroDto)
        {
            if (heroDto == null) throw new InvalidCastException("hero bilgileri eksik !");

            var validationResult= await _superheroValidator.ValidateAsync(heroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var addedhero = _mapper.Map<SuperHero>(heroDto);        
            await _dbcontext.AddAsync(addedhero);
            await _dbcontext.SaveChangesAsync();

            return addedhero;

        }
        public async Task<SuperHero> UpdateSuperHero(SuperHeroDto heroDto)
        {
            if (heroDto is null)
                throw new InvalidOperationException("Böyle bir hero yok."); // put ve postta dto kullandım . Dto yu güncelledim unutma 

            var updatedhero = _mapper.Map<SuperHero>(heroDto);
            _dbcontext.SuperHeroes.Update(updatedhero);
            await _dbcontext.SaveChangesAsync();

            return (updatedhero);

        }
        public async Task<IEnumerable<SuperHero>> GetPlaceWithSuperHeroes(int id)
        {
            var placewithheroes = await _dbcontext.SuperHeroes.Where(sh => sh.PlaceId == id).ToListAsync();
            return placewithheroes;
        }


    }
}
