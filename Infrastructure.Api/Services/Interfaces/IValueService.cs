using System;
using System.Collections.Generic;
using System.Text;
using Application.Api.Interfaces;
using Domain.Api.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Api.Services.Interfaces
{
    public interface IValueService
    {
        Task Update(Value valueEntity);
    }
}
