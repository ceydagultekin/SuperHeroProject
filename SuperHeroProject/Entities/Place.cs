using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroProject.Entities
{
    public class Place
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SuperHero> SuperHeroes { get; set; }

    }
}
