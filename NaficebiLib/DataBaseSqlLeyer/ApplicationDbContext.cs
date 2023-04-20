using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.DataBaseSqlLeyer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Clerk> Clerk { get; set; }
        public DbSet<CourtCase> CourtCase {get;set; }
        public DbSet<Numbers> Numbers { get; set; }
        public ApplicationDbContext()
            
        {
                Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var connectionString = $"Data Source={Path.Combine(Environment.CurrentDirectory,"court.db")}";
            optionsBuilder.UseSqlite(connectionString);
            
        }
    }
}
