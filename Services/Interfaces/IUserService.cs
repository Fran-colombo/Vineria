using Common.Models;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IUserService
    {
        int AddUser(UserForCreationDto userDto);
        User? AuthenticateUser(string username, string password);
        User? GetUserByUsername(string username);
        IEnumerable<User> GetUsers();
    }
}