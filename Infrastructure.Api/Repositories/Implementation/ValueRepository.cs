using System;
using System.Collections.Generic;
using System.Text;
using Domain.Api.Entities;
using Application.Api.Interfaces;

namespace Infrastructure.Api.Repositories.Implementation
{
    public class ValueRepository: BaseRepository<Value>, IValueRepository
    {
        public ValueRepository(IDbContext context) : base(context)
        {

        }
    }
}
