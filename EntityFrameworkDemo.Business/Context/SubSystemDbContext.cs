using EntityFrameworkDemo.Business.Connection;
using EntityFrameworkDemo.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Business.Context
{
    public class SubSystemDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<SubSystem> SubSystems { get; set; }

        public SubSystemDbContext() { }

        public SubSystemDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Hidden.GetConnectionString());
            }
        }
    }
}
