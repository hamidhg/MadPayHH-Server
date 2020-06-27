using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MadPayHH.Common.Helpers;
using MadPayHH.Data.Models;
using MadPayHH.Repo.Infrastructure;
using MadPayHH.Data.DatabaseContext;
using MadPayHH.Repo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace MadPayHH.Repo.Class
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext _db;

        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (_db ?? (MadpayHHDbContext)_db);
        }

   

        public async Task<bool> UserExists(string username)
        {
            if (await GetAsync(u => u.Username == username)!=null)
                return true;
            else
                return false;

        }

        //public Task<User> LoginUserExists(string username)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
