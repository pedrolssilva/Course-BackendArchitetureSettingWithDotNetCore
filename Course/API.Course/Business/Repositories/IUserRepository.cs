using API.Course.Business.Entities;

namespace API.Course.Business.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Commit();
        User GetUser(string login);
    }
}
