namespace MvcCatalog.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string username);
        User Get(string username, string password);
    }
}
