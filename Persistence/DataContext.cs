using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{

    // Adding an Entity Framework Db Context
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Activity> Activities {get;set;}
        
    }
}