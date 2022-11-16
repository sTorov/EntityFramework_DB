using Microsoft.EntityFrameworkCore;

namespace EF_Migration
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ASUS\SQLEXPRESS;Database=EF;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
