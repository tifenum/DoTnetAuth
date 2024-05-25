// In IUserRepository.cs
using Models;

namespace Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        User AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
