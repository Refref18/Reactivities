using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {//base the constructor of db
            
        }
        public DbSet<Activity> Activities{ get; set; }//the name of the table: all activies
    }
}