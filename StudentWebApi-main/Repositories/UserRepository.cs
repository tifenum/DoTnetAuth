// In UserRepository.cs
using Data;
using Models;
using System.Linq;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentDB _studentDB;

        public UserRepository(StudentDB studentDB)
        {
            _studentDB = studentDB;
        }

        public User GetUserById(int userId)
        {
            return _studentDB.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _studentDB.Users.FirstOrDefault(u => u.Username == username);
        }

        public User GetUserByEmail(string email)
        {
            return _studentDB.Users.FirstOrDefault(u => u.Email == email);
        }

        public User AddUser(User user)
        {
            _studentDB.Users.Add(user);
            _studentDB.SaveChanges();
            return user;
        }

        public void UpdateUser(User user)
        {
            _studentDB.Users.Update(user);
            _studentDB.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _studentDB.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                _studentDB.Users.Remove(user);
                _studentDB.SaveChanges();
            }
        }
    }
}
