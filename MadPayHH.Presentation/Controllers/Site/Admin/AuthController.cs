using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPayHH.Data.DatabaseContext;
using MadPayHH.Data.Models;
using MadPayHH.Repo.Infrastructure;
using MadPayHH.Services.Site.Admin.Auth.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MadPayHH.Presentation.Controllers.Site.Admin
{
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayHHDbContext> _db;
        private readonly IAuthService _authService;

        public AuthController(IUnitOfWork<MadpayHHDbContext> db, IAuthService authService)
        {
            _db = db;
            _authService = authService;  
        }

        public async Task<IActionResult> Register(string username, string password)
        {
            username = username.ToLower();
            if (await _db.UserRepository.UserExists(username))
                return BadRequest("این نام کاربری قبلا ثبت شده است ");
            var userTocreated = new User
            {
                Username = username,
                Address = "",
                City = "",
                DateOfBirth = "",
                Gender = "",
                IsActive = true,
                Name = "",
              
                PhoneNumber = "",
                Status = true,
               
            };
            var CreatedUser = await _authService.Register(userTocreated,password);
            return StatusCode(201);

        }

      
    }
}
