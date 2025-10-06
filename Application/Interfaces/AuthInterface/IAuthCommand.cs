using Application.Models.UserModel;
using Domain.Entities;

namespace Application.Interfaces.AuthInterface
{
    public interface IAuthCommand
    {
        Task<UserDTO> Insert(UserDTO user);
    }
}
