using Models.DTO;
using Models;

namespace Mappers
{
    public interface IUserMapper
    {
        Models.User MapToUser(Models.DTO.UserDTO userDTO);
        Models.DTO.UserDTO MapToUserDTO(Models.User user);
    }
}
