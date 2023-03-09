using reviewWIC.Areas.Identity.Data;
using reviewWIC.Models.Repositories;

namespace reviewWIC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) { 
            _context = context;
        }

        public ApplicationUser GetById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        ICollection<ApplicationUser> IUserRepository.GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
