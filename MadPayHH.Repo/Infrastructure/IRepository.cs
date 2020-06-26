using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MadPayHH.Repo.Infrastructure
{
  public  interface IRepository<TEntitiy> where TEntitiy : class
  {
      void Insert(TEntitiy entitiy);
      void Update(TEntitiy entitiy);
      void Delete(object id);
      void Delete(TEntitiy entitiy);
      void Delete(Expression<Func<TEntitiy, bool>> where);

      TEntitiy GetById(object id);
      IEnumerable<TEntitiy> GetAll();
     TEntitiy Get(Expression<Func<TEntitiy, bool>> where);
     IEnumerable<TEntitiy> GetMany(Expression<Func<TEntitiy, bool>> where);




     Task InsertAsync(TEntitiy entitiy);
    
     //Task DeleteAsync(object id);
     //Task DeleteAsync(TEntitiy entitiy);
     //Task DeleteAsync(Expression<Func<TEntitiy, bool>> where);

     Task<TEntitiy> GetByIdAsync(object id);
     Task<IEnumerable<TEntitiy>> GetAllAsync();
     Task<TEntitiy> GetAsync(Expression<Func<TEntitiy, bool>> where);
     Task<IEnumerable<TEntitiy>> GetManyAsync(Expression<Func<TEntitiy, bool>> where);


    }

}
