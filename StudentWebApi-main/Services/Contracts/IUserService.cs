using Models;

namespace Services
{
    public interface IUserService
    {
        User GetUserById(int userId);
        User GetUserByUsername(string username);
        User RegisterUser(string username, string password, string email);
        User Login(string username, string password);
        void Logout();
        void UpdateUser(User user);
        User GetUserByEmail(string email);
        void UpdatePassword(User user, string newPassword);
    }
}