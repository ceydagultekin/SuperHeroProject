using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroProject.Entities.Dto
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }   
    }
}
