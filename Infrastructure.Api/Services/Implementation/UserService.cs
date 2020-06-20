using Application.Api.Interfaces;
using Common.Api.Helper;
using Domain.Api.Entities;
using Infrastructure.Api.Repositories.Implementation;
using Infrastructure.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Api.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Login(string UserName, string password)
        {
            var user = await _userRepository.Find(m => m.Username == UserName);
            if (user == null)
                return null;
            var UserInfo = user.FirstOrDefault();
            if (!CommonHelper.VerifyPasswordHash(password, UserInfo.PasswordHash, UserInfo.PasswordSalt))
                return null;
            return UserInfo;
        }
        public async Task<User> Register(User UserName, string password)
        {
            var user = await _userRepository.Find(m => m.Username == UserName.Username);
            byte[] passwordHash, passwordSalt;
            CommonHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            UserName.PasswordHash = passwordHash;
            UserName.PasswordSalt = passwordSalt;
            await _userRepository.Add(UserName);
            await _userRepository.Complete();
            return UserName;
        }


        public async Task<bool> UserExist(string UserName)
        {
            var users = await _userRepository.Find(m => m.Username == UserName);
            return users.Any();
        }
    }
}
