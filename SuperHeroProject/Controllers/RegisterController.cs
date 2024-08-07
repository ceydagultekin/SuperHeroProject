using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroProject.Entities;
using SuperHeroProject.Entities.Dto;
using SuperHeroProject.Interfaces;

namespace SuperHeroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public RegisterController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var userExists = _userService.UserExists(registerDto.Email);
            if (userExists)
            {
                return BadRequest("Bu kullanıcı kayıtlı !");
            }
            var user = new AppUsers
            {
                Email = registerDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
            };
            _userService.CreateUser(user);
            return Ok("Kullanıcı başarıyla oluşturuldu .");
        }
    }
}
