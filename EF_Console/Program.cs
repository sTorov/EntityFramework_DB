namespace EF_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //using(var db = new AppContext())
            //{
            //    var user1 = new User { Name = "Arthur", Role = "Admin" };
            //    var user2 = new User { Name = "Klim", Role = "User" };

            //    db.Users.Add(user1);
            //    db.Users.Add(user2);
            //    db.SaveChanges();
            //}

            using(var db = new AppContext())
            {
                var user3 = new User { Name = "Alice", Role = "User"/*, Id = 3*/ };
                var user4 = new User { Name = "Bob", Role = "User" };
                var user5 = new User { Name = "Bruce", Role = "User", Id = 5 };

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

                Console.ReadKey();
            }
        }
    }
}