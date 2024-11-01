using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        int AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        User? GetUserByUsername(string username);
    }
}