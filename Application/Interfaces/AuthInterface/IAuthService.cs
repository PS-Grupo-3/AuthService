using Application.Models.UserModel;
using Domain.Entities;

namespace Application.Interfaces.AuthInterface
{
    public interface IAuthService
    {
        Task<UserDTO> Register(UserDTO registerUserDTO);
        Task<UserDTO> Login(LoginUserDTO loginUserDTO);
        Task<UserDTO> GetCurrentUser(Guid userId);
    }
}
