using EF_Console.Models;

namespace EF_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Начало работы с EF
            using(var db = new AppContext())
            {
            //    var user1 = new User { Name = "Arthur", Role = "Admin" };
            //    var user2 = new User { Name = "Klim", Role = "User" };

            //    db.Users.Add(user1);
            //    db.Users.Add(user2);
            //    db.SaveChanges();
            }

            //CRUD
            using(var db = new AppContext())
            {
                //var user3 = new User { Name = "Alice", Role = "User"/*, Id = 3*/ };
                //var user4 = new User { Name = "Bob", Role = "User" };
                //var user5 = new User { Name = "Bruce", Role = "User", Id = 5 };

                #region Add
                ////Добавление одиночного пользователя
                //db.Users.Add(user3);
                ////Добавление нескольких пользователей
                //db.Users.AddRange(user4, user5);
                #endregion

                #region Save
                ////Сохранение изменений
                //db.SaveChanges();
                #endregion

                #region Delete
                //Удаление пользователя из базы данных
                //db.Users.Remove(user5);         //RemoveRange() - для удаление сразу нескольких записей
                //db.SaveChanges();
                //Ещё один способ удаления записи из БД
                //db.Entry(user3).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                //db.SaveChanges();
                #endregion

                #region Select
                ////Получение списка всех пользователей из БД
                //var allUsers = db.Users.ToList();
                ////Получение пользователей с ролью 'Admin'
                //var admins = db.Users.Where(user => user.Role == "Admin").ToList();
                #endregion

                #region Update
                ////Выбор первого пользователя в таблице
                //var firstUser = db.Users.FirstOrDefault();
                ////Обновление данных в сущности
                //firstUser.Email = "simpleemail@gmail.com";
                //db.SaveChanges();
                #endregion
            }

            //Работа с зависимостями моделей
            using(var db = new AppContext())
            {
                #region OneToOne
                //var user1 = new User { Name = "Arthur", Role = "Admin" };
                //var user2 = new User { Name = "Bob", Role = "Admin" };
                //var user3 = new User { Name = "Clark", Role = "User" };
                //var user4 = new User { Name = "Dan", Role = "User" };

                //// Добавляем user2 и сохраняем, чтобы получить Id
                //db.Users.Add(user2);
                //db.SaveChanges();
                //db.Users.AddRange(user1, user3, user4);

                //var user1Creds = new UserCredential { Login = "ArthurL", Password = "qwerty123" };
                //var user2Creds = new UserCredential { Login = "BobJ", Password = "asdfgh585" };
                //var user3Creds = new UserCredential { Login = "ClarkK", Password = "111zlt777" };
                //var user4Creds = new UserCredential { Login = "DanE", Password = "zxc333vbn" };

                //user1Creds.User = user1;
                //user2Creds.UserId = user2.Id;
                //user3.UserCredential = user3Creds;
                //user4.UserCredential = user4Creds;

                //// Не добавляем user1Creds в БД
                //db.UserCredentials.AddRange(user2Creds, user3Creds, user4Creds);

                //db.SaveChanges();
                #endregion

                #region OneToMany
                //var company1 = new Company { Name = "SF" };
                //var company2 = new Company { Name = "VK" };
                //var company3 = new Company { Name = "FB" };

                //db.Companies.Add(company3);
                //db.SaveChanges();

                //var user1 = new User { Name = "Arthur", Role = "Admin" };
                //var user2 = new User { Name = "Bob", Role = "Admin" };
                //var user3 = new User { Name = "Clark", Role = "User" };

                //user1.Company = company1;
                //company2.Users.Add(user2);
                //user3.CompanyId = company3.Id;

                //db.Companies.AddRange(company1, company2);
                //db.Users.AddRange(user1, user2, user3);

                //db.SaveChanges();
                #endregion

                #region ManyToMany
                //var topic1 = new Topic() { Name = "Раздел 1" };
                //var topic2 = new Topic() { Name = "Раздел 2" };
                //var topic3 = new Topic() { Name = "Раздел 3" };

                //var user1 = new User() { Name = "Пользователь 1", Email = "email1@gmail.com" };
                //var user2 = new User() { Name = "Пользователь 2", Email = "email2@gmail.com" };
                //var user3 = new User() { Name = "Пользователь 3", Email = "email3@gmail.com" };
                //var user4 = new User() { Name = "Пользователь 4", Email = "email4@gmail.com" };

                //topic1.Users.AddRange(new List<User> { user3, user4 });
                //topic2.Users.AddRange(new List<User> { user1, user2 });

                //user1.Topics.AddRange(new List<Topic> { topic1, topic3 });

                //db.Users.AddRange(user1, user2, user3, user4);
                //db.Topics.AddRange(topic1, topic2, topic3);

                //db.SaveChanges();
                #endregion
            }
        }
    }
}