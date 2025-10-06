using Application.Interfaces.AuthInterface;
using Application.Models.UserModel;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys.AuthQuery
{
    public class AuthQuerys : IAuthQuery
    {
        private readonly AppDbContext _context;
        public AuthQuerys(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> Get(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                throw new ArgumentException("Usuario no encontrado");
                return null;
            }
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Role = user switch
                {
                    Domain.Entities.Administrator => "Administrator",
                    Domain.Entities.Customer => "Customer"
                },
                TeamName = (user as Administrator)?.TeamName,
                UserName = (user as Customer)?.UserName
            };
            return userDTO;

        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new ArgumentException("Usuario no encontrado");
                return null;
            }
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Role = user switch
                {
                    Domain.Entities.Administrator => "Administrator",
                    Domain.Entities.Customer => "Customer"
                },
                TeamName = (user as Administrator)?.TeamName,
                UserName = (user as Customer)?.UserName
            };
            return userDTO;
        }
    }
}
