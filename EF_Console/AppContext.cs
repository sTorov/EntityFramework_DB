using EF_Console.Models;
using EF_Console.Models.Conf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        //Fluent IPA - определение модели БД

        #region ModelBuilder

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Включение сущности в модель
            modelBuilder.Entity<User>();        //DbSet<User> Users

            //Составной ключ
            modelBuilder.Entity<User>().HasKey(u => new { u.Id, u.Name }).HasName("UserPK");    //.HasKey(u => u.Id)
            //Альтернативный ключ (unique) (составной)
            modelBuilder.Entity<Country>().HasAlternateKey(c => new { c.Name, c.Prop });    //.HasAlrenateKey(c => c.Name)      UNIQUE

            //Исключить сущность из модели
            modelBuilder.Ignore<Country>();
            //Исключить свойство сущности
            modelBuilder.Entity<Company>().Ignore(c => c.Users);

            //Назначение свойств сущностей
            //Property() - назначение поля как свойства сущности
            //HasField() - назначение поля для свойства сущности
            modelBuilder.Entity<Country>().Property("Prop").HasField("prop");
            modelBuilder.Entity<Country>().Property("field");

            //Сопостовление столбцов и таблиц
            modelBuilder.Entity<Country>().ToTable("Example");      //Имя для таблици от сущности Country
            modelBuilder.Entity<Country>().Property(c => c.Name).HasColumnName("Name");     //Имя колонки
            modelBuilder.Entity<Country>().Property(c => c.Name).IsRequired();  //Not Null

            //Создание индекса
            modelBuilder.Entity<Country>()
                .HasIndex(c => new { c.Index, c.Name })         //составной индекс
                .IsUnique()                                     //уникальный
                .HasDatabaseName("MyIndex")                     //имя индекса
                .HasFilter("[Index] IS NOT NULL");              //частичная индексация по условию

            //Автоматическое заполнение свойств
            modelBuilder.Entity<Country>().Property(c => c.Id).ValueGeneratedNever();   //Автоинткремент выкл.
            modelBuilder.Entity<Country>().Property(c => c.Index).HasDefaultValue(18);  //Переопределение заначения по умолчанию
            modelBuilder.Entity<Country>().Property(c => c.Date).HasDefaultValueSql("DATETIME('now')");     //Переопределение значения по умолчанию при помощи SQL запроса (SQLite)
            modelBuilder.Entity<Country>().Property(c => c.OtherId).HasComputedColumnSql("Id || ' ' || Name");      //Вычисляемое значение поля

            //Ограничения
            //1 - свойство для ограничения, 2 - SQL, 3 - параметры для создания ограничения (имя)
            modelBuilder.Entity<Country>().HasCheckConstraint("Index", "Index > 0 AND index < 120", c => c.HasName("CK_Country_Index"));
            //или
            modelBuilder.Entity<Country>().ToTable("Country", c => c.HasCheckConstraint("Index", "Index > 0 AND index < 120").HasName("CK_Country_Index"));

            modelBuilder.Entity<Country>().Property(c => c.Name).HasMaxLength(50);      //Ограничение по длинне значения    (nvarchar(50))


            //Инициализация БД начальными данными
            //При этом способе ОБЯЗАТЕЛЬНО нужно указывать значения первичного ключа, вне зависимости от присутствия автогенерации значения
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Tom" },
                    new User { Id = 2, Name = "Alice" },
                    new User { Id = 3, Name = "Sam" }
                );


            //Конфигурации
            modelBuilder.ApplyConfiguration(new CountryConf());     //Применение конфигураций, созданных в отдельном классе
            //или
            modelBuilder.Entity<Country>(CountryConfig);            //Применение конфигураций при помощи отдельного метода
            //или
            new CountryConf().Configure(modelBuilder.Entity<Country>());        //ещё один способ применения конфигураций

        }

        public void CountryConfig(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Table_Name").Property(c => c.Id).IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name");
        }

        #endregion
    }
}
