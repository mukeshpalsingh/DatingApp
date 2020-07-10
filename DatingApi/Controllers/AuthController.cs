using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Api.Interfaces;
using Common.Api.Dtos;
using Domain.Api.Entities;
using Infrastructure.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DatingApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, IUserService userService, IUserRepository userRepository,IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            this._configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
           if(await _userService.UserExist(userForRegisterDto.Username))
            return BadRequest("User already exists!");
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
            };
           await _userService.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }
        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            await _userService.UserExist("mukeshmehay@ymail.com");
            return BadRequest("");
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                ///throw new Exception("Computer say no!");
                var userFromRepo = await _userService.Login(userForLoginDto.Username, userForLoginDto.Password);
                if (userFromRepo == null)
                    return Unauthorized();
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.Username)
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescription);

                return Ok(new
                {
                    token = tokenHandler.WriteToken(token)
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Computer really say no!");
            }
            
        }
    }
}