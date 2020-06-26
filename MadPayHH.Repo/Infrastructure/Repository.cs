using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MadPayHH.Repo.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MadPayHH.Repo.Infrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region Constructor
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #endregion

        #region NormalCode
        public void Insert(TEntity entitiy)
        {
            if (entitiy == null)
                throw new ArgumentException("There is no entity");
            _dbSet.Add(entitiy);
        }

        public void Update(TEntity entitiy)
        {
            if(entitiy==null)
                throw new ArgumentException("There is no entity");
            _dbSet.Update(entitiy);
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new ArgumentException("there is no entity");
            _dbSet.Remove(entity);

        }

        public void Delete(TEntity entitiy)
        {
            _dbSet.Remove(entitiy);
        }

        public void Delete(Expression<Func<TEntity, bool>> @where)
        {
            IEnumerable<TEntity> obj = _dbSet.Where(where).AsEnumerable();
            foreach (TEntity item in obj)
            {
                _dbSet.Remove(item);
            }
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> @where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> @where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }

        #endregion

        #region Async
        public async Task InsertAsync(TEntity entitiy)
        {
            await _dbSet.AddAsync(entitiy);
        }

     
     

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> @where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> @where)
        {
            return await _dbSet.Where(where).ToListAsync();
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
                    _dbContext.Dispose();
                }
            }

            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        ~Repository()
        {
            Dispose(false);
        }
        #endregion

    }
}
