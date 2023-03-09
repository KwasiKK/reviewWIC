using Microsoft.AspNetCore.Identity;

namespace reviewWIC.Models.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
