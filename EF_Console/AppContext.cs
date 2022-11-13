using Microsoft.EntityFrameworkCore;

namespace EF_Console
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ASUS\SQLEXPRESS;Database=EF;" + 
                "Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
