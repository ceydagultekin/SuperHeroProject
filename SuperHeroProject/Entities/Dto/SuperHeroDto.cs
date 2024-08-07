using FluentValidation;
using FluentValidation.Validators;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroProject.Entities.Dto
{
    public class SuperHeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PlaceId { get; set; }  // PlaceId nullable olabilir
    }

   
}