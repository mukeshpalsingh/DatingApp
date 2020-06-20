using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Api.Services.Interfaces;
using Domain.Api.Entities;
using Common.Api;
using Microsoft.AspNetCore.Authorization;

namespace DatingApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IValueService _valueService;
        private readonly IUserService _userService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IValueService valueService, IUserService userService)
        {
            _logger = logger;
            _valueService = valueService;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var value = new Value
            {
                Name = "test"

            };
            var update = new Value
            {
                Name = "mukesh",
                Id = 1
            };

            //await _userService.Add(user);
            //await _userService.Complete();
            //var GetUser= _userService.Find(m => m.Username == "mukeshmehay@ymail.com").Result.FirstOrDefault();
            //if (GetUser != null)
            //    if(CommonHelper.VerifyPasswordHash("Test@1234", GetUser.PasswordHash, GetUser.PasswordSalt))
            //    {
            //     var ma=   GetUser;
            //    }
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetValue")]
        public async Task<IEnumerable<WeatherForecast>> GetValue()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
