using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MadPayHH.Data.Models;

namespace MadPayHH.Services.Site.Admin.Auth.Repositories.Interface
{
   public  interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
    }
}
