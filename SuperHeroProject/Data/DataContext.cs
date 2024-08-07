using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;
using SuperHeroProject.Entities;

namespace SuperHeroProject.Data 
{
    public class DataContext:DbContext
    {
        
        public DataContext()
        {         

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<AppUsers> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.Entity<SuperHero>()
            .HasOne(sh => sh.Place)
            .WithMany(p => p.SuperHeroes)
            .HasForeignKey(sh => sh.PlaceId);
        }
    }
}
