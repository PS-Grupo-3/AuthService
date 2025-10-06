using Application.Models.UserModel;

namespace Application.Interfaces.AuthInterface
{
    public interface IAuthQuery
    {
        Task<UserDTO> Get(string email,string password);
        Task<UserDTO> GetById(Guid id);
    }
}
