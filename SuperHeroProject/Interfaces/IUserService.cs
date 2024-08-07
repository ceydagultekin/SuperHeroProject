using SuperHeroProject.Entities;

namespace SuperHeroProject.Interfaces
{
    public interface IUserService
    {
        public bool UserExists(string email);
        public void CreateUser(AppUsers user);
        public AppUsers GetUserByEmail(string email);
       
    }
}
