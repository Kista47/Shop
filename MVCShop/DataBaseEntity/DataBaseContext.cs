using Microsoft.EntityFrameworkCore;
using MVCControllers.DataBaseEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCControllers.DataBaseEntity
{
    public class DataBaseContext : DbContext
    {
        public DbSet<DbToy> DbToys { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
