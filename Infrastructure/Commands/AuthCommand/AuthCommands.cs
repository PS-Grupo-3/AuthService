using Application.Interfaces.AuthInterface;
using Application.Models.UserModel;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Commands.AuthCommand
{
    public class AuthCommands : IAuthCommand
    {
        private readonly AppDbContext _context;
        public AuthCommands(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> Insert(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentException("El usuario creado no puede ser nulo");
            }
            if (user.Role.ToLower() == "administrator")
            {
                var newUser = new Administrator
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Phone = user.Phone,
                    TeamName = user.TeamName
                };
                await _context.Users.AddAsync(newUser);
            }
            if (user.Role.ToLower() == "customer")
            {
                var newUser = new Customer
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Phone = user.Phone,
                    UserName = user.UserName
                };
                await _context.Users.AddAsync(newUser);
            }
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
