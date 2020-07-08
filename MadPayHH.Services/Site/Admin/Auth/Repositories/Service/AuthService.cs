using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MadPayHH.Common.Helpers;
using MadPayHH.Data.DatabaseContext;
using MadPayHH.Data.Models;
using MadPayHH.Repo.Infrastructure;

using MadPayHH.Services.Site.Admin.Auth.Repositories.Interface;

namespace MadPayHH.Services.Site.Admin.Auth.Repositories.Service
{
   public class AuthService:IAuthService
   {
       private readonly IUnitOfWork<MadpayHHDbContext> _db;

       public AuthService(IUnitOfWork<MadpayHHDbContext> db)
       {
           _db = db;
       }


        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            Utilities.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _db.UserRepository.InsertAsync(user);
            await _db.SaveAsync();
            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await  _db.UserRepository.GetAsync(u => u.Username == username);
            if (user == null)
            {
                return null;
            }

            if (!Utilities.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }


    }
}
