using Microsoft.AspNetCore.Identity;
using reviewWIC.Areas.Identity.Data;
using reviewWIC.Models.Repositories;

namespace reviewWIC.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }

    }
}
