using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MadPayHH.Data.Models;
using MadPayHH.Repo.Infrastructure;

namespace MadPayHH.Repo.Repositories.Interface
{
   public interface IUserRepository:IRepository<User>
   {
       Task<User> UserExists(string username);

    }
}
