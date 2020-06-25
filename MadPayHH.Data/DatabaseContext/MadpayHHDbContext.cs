using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MadPayHH.Data.DatabaseContext
{
     class MadpayHHDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MadpayHHdb;Integrated Security=True;MultipleActiveResultSets=True;");
        }
    }
}
