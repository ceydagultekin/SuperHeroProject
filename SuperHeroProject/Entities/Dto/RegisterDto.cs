using System.ComponentModel.DataAnnotations;

namespace SuperHeroProject.Entities.Dto
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
