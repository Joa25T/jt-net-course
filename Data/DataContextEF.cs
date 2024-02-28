using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextEF(IConfiguration config) : DbContext 
    {
        public DbSet<Computer>? Computer{ get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (options.IsConfigured) return;
            string? sqlConnection = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(sqlConnection, options => options.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<Computer>().HasKey(c => c.Motherboard);
                //.ToTable("Computer","TutorialAppSchema");
        }
    }
}