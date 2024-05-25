using Models;
using Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public User RegisterUser(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email
            };
            return _userRepository.AddUser(user);
        }

        public User Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }

        public void Logout()
        {
            //fassa5 el token enti wel tecknologie li thb te5dem beha
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public void UpdatePassword(User user, string newPassword)
        {
            user.Password = newPassword;
            _userRepository.UpdateUser(user);
        }

    }
}

