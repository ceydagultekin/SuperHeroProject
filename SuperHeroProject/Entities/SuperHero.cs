using EntityFrameworkCore.EncryptColumn.Attribute;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroProject.Entities
{
    public class SuperHero
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Place 
        //için güncellenen kısım sonraki iki satır buradaki PlaceId , Place 'de Id ye karşılıktır
        [ForeignKey("PlaceId")]
        public int? PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
