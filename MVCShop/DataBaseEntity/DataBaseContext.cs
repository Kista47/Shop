using Microsoft.EntityFrameworkCore;
using MVCShop.DataBaseEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.DataBaseEntity
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
