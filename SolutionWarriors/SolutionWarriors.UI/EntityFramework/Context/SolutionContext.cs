using Microsoft.EntityFrameworkCore;
using SolutionWarriors.UI.EntityFramework.Configuration;
using SolutionWarriors.UI.Models;

namespace SolutionWarriors.UI.EntityFramework.Context
{
    public class SolutionContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SolutionWarriorsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
