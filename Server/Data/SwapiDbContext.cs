using Microsoft.EntityFrameworkCore;
using WebAssemblyTest.Shared;

namespace WebAssemblyTest.Server.Data
{
    public class SwapiDbContext : DbContext
    {
        public SwapiDbContext(DbContextOptions<SwapiDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Starship> Starship { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<User> User { get; set; }
    }
}
