using Application.Api.Interfaces;
using Domain.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Api.Repositories.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext context) : base(context)
        {

        }
    }
}
