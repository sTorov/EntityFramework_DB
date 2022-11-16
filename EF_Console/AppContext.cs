using EF_Console.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Console
{
    public class AppContext : DbContext
    {
        //Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        //Объекты таблицы Companies
        public DbSet<Company> Companies { get; set; }

        //LINQ To Entities
        //public AppContext()
        //{
        //    //Удаление модели БД
        //    Database.EnsureDeleted();
        //    //Создание модели БД
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ASUS\SQLEXPRESS;Database=EF;" + 
                "Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
