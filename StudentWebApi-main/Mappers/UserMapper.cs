using Models.DTO;
using Models;

namespace Mappers
{
    public class UserMapper : IUserMapper
    {
        public User MapToUser(UserDTO userDTO)
        {
            return new User
            {
                UserId = userDTO.UserId,
                Username = userDTO.Username,
                Email = userDTO.Email
            };
        }

        public UserDTO MapToUserDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}
