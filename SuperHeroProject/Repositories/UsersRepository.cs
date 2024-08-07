using SuperHeroProject.Interfaces;
using SuperHeroProject.Data;
using SuperHeroProject.Entities;

namespace SuperHeroProject.Repositories
{
    public class UsersRepository:IUserService
    {
        private readonly DataContext _dbcontext;

        public UsersRepository(DataContext dbcontext)
        {
             _dbcontext = dbcontext; 
        } 
        public bool UserExists(string email)
        {
            return _dbcontext.AppUsers.Any(u => u.Email == email);
        }
        public void CreateUser(AppUsers user)
        {
            _dbcontext.AppUsers.Add(user);
            _dbcontext.SaveChanges();
        }
        public AppUsers GetUserByEmail(string email)
        {
            return _dbcontext.AppUsers.SingleOrDefault(u => u.Email == email);
        }
    }
}
