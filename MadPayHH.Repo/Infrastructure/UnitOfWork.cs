using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MadPayHH.Repo.Class;
using Microsoft.EntityFrameworkCore;

namespace MadPayHH.Repo.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()

    {
        #region Ctor
        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }

        #endregion

        #region Save


        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
        #endregion

        #region UserRepository
        private UserRepository userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_db);
                }

                return userRepository;
            }
        }
        #endregion


        #region Dispose

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing == true)
                {
                    _db.Dispose();
                }
            }

            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
