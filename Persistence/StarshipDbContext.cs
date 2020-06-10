using System;
using System.Collections.Generic;
using System.Text;
using Domain.Starships;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class StarshipDbContext : DbContext
    {
        public DbSet<StarShip> Starships { get; set; }
        public StarshipDbContext(DbContextOptions opt) : base(opt)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Starship;Trusted_Connection=True", b => b.MigrationsAssembly("Service"));
            }
        }
    }
}
