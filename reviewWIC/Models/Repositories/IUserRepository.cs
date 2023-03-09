using reviewWIC.Areas.Identity.Data;

namespace reviewWIC.Models.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();
        ApplicationUser GetById(string id);
        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
