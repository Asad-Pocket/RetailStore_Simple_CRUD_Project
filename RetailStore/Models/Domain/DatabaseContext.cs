using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace RetailStore.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {

        }
        public DbSet<Item> ItemList { get; set; }
    }
}