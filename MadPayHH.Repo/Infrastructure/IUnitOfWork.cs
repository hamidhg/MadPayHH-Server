using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MadPayHH.Repo.Class;
using Microsoft.EntityFrameworkCore;

namespace MadPayHH.Repo.Infrastructure
{
  public  interface IUnitOfWork<TContext>:IDisposable where TContext:DbContext
  {
      UserRepository UserRepository { get;}
      void Save();
      Task<int> SaveAsync();

  }
}
