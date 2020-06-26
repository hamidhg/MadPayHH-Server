using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MadPayHH.Data.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()

    {
        #region Ctor
        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db=new TContext();
        }

        #endregion

        #region Save

       public void Save()
       {
           _db.SaveChanges();
       }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }
        #endregion
        
        #region Dispose

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if(disposing==true)
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
