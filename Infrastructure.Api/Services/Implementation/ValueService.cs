using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Api.Repositories.Implementation;
using Application.Api.Interfaces;
using Infrastructure.Api.Services.Interfaces;
using System.Threading.Tasks;
using Domain.Api.Entities;

namespace Infrastructure.Api.Services.Implementation
{
    public class ValueService: IValueService
    {
        private readonly IValueRepository _valueRepository;
        public ValueService(IValueRepository valueRepository) 
        {
            _valueRepository= valueRepository;
        }
        public async Task Update(Value valueEntity)
        {
            Value entity = await _valueRepository.Get(valueEntity.Id);
            entity.Name = valueEntity.Name;
        }
    }
}
