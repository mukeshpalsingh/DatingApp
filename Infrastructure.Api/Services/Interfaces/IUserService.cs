using Application.Api.Interfaces;
using Domain.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(string UserName, string Password);
        Task<bool> UserExist(string UserName);
        Task<User> Register(User UserName, string password);
    }
}
