namespace reviewWIC.Models.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get;  }
        IRoleRepository Role { get; }
    }
}
