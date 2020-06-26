using System;
using System.Collections.Generic;
using System.Text;
using MadPayHH.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MadPayHH.Data.DatabaseContext
{
   public  class MadpayHHDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MadpayHHdb;Integrated Security=True;MultipleActiveResultSets=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<BankCard> BankCards { get; set; }

    }
}
