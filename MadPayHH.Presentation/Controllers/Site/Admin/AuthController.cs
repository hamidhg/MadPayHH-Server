using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MadPayHH.Common.ErrorAndMessage;
using MadPayHH.Data.DatabaseContext;
using MadPayHH.Data.Dto.Site.Admin;
using MadPayHH.Data.Models;
using MadPayHH.Repo.Infrastructure;
using MadPayHH.Services.Site.Admin.Auth.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MadPayHH.Presentation.Controllers.Site.Admin
{
    [Authorize]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayHHDbContext> _db;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        public AuthController(IUnitOfWork<MadpayHHDbContext> db, IAuthService authService, IConfiguration configuration)
        {
            _db = db;
            _authService = authService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegsiterDto userForRegsiterDto)
        {

            userForRegsiterDto.Username = userForRegsiterDto.Username.ToLower();
            if (await _db.UserRepository.UserExists(userForRegsiterDto.Username))
            {

                return BadRequest(new ReturnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = "نام کاربری وجود ندارد",


                });
            }

            var userTocreated = new User
            {
                Username = userForRegsiterDto.Username,
                Name = userForRegsiterDto.Name,
                PhoneNumber = userForRegsiterDto.PhoneNumber,
                Address = "",
                City = "",
                DateOfBirth = DateTime.Now,
                Gender = "",
                IsActive = true,
                Status = true,

            };
            var CreatedUser = await _authService.Register(userTocreated, userForRegsiterDto.Password);
            return StatusCode(201);

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _authService.Login(userForLoginDto.Username, userForLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized(new ReturnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = "نام کاربری و رمز عبور وجود ندارد",


                });
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = userForLoginDto.IsRemember ? DateTime.Now.AddDays(1) : DateTime.Now.AddHours(2),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDes);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });


        }




        [AllowAnonymous]
        [HttpGet("GetValue")]
        public async Task<IActionResult> GetValue()
        {


            return Ok(new ReturnMessage()
            {
                status = true,
                title = "اوکی",
                message = "",


            });

        }


       
        [HttpGet("GetValues")]
        public async Task<IActionResult> GetValues()
        {
            
            return Ok(new ReturnMessage()
            {
                status = true,
                title = "اوکی",
                message = "",


            });

        }
    }
}
