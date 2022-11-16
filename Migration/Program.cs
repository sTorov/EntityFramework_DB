namespace EF_Migration
{
    /*
     * При уже не пустой БД есть 2 пути:
     * 
     * 1. Удалить все таблицы БД и применить миграцию. При этом все данные будут потеряны
     * 
     * или
     * 
     * 2. Убрать первую миграцию из папки, оставив файл  ***ModelSnapshot. Затем при изменении модели создать новую миграцию и применить её.
     * 
     * 
     * Консоль диспетчера пакетов (Package Manager Console) - запустить, незабыть выбрать нужный проект
     * 
     * Add-Migration Initial -  создание миграции Initial   (-Namespace -изменить пространство имён  -OutputDir - задать папку сохранения файлов миграции)
     * Update-Database - применение созданную миграцию
     * Remove-Migration - удалить последнюю созданную миграцию
     * Update-Database -Migration: 20221116170950_AddedCompanyCity  -   откатывает или обновляет состояние БД до указанной миграции
     * Update-Database -Migration: 0 - откатить БД до инициализации
     * Get-Migration - получение списка миграций
     * Script-Migration - создать SQL скрипт для обновления из пустой БД до последней миграции
     * Script-Migration AddAuditTable - создать SQL скрипт для обновления от указанной до последней миграции
     * Script-Migration AddNewTables AddAuditTable - создать SQL скрипт для обновления от указанной до указанной миграции
     */

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var company1 = new Company { Name = "SF" };
                var company2 = new Company { Name = "VK" };
                var company3 = new Company { Name = "FB" };

                db.Companies.AddRange(company1, company2, company3);

                var user1 = new User { Name = "Arthur", Role = "Admin", Company = company1 };
                var user2 = new User { Name = "Bob", Role = "Admin", Company = company2 };
                var user3 = new User { Name = "Clark", Role = "User", Company = company2 };
                var user4 = new User { Name = "Dan", Role = "User", Company = company3 };

                db.Users.AddRange(user1, user2, user3, user4);

                db.SaveChanges();
            }
        }
    }
}