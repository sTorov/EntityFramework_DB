namespace EF_Console.Models
{
    //Один к одному
    class One_To_one
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string? Email { get; set; }
            public string Role { get; set; }

            //Навигационное свойство
            public UserCredencial UserCredencial { get; set; }
        }

        public class UserCredencial
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }

            //Внешний ключ
            public int UserId { get; set; }
            //Навигационное свойство
            public User User { get; set; }
        }
    }

    //Один ко многим
    class One_To_Many
    {
        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }

            //Навигационное свойство
            public List<User> Users { get; set; }
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }

            //Внешний ключ
            public int CompanyId { get; set; }
            //Навигационное свойство
            public Company Company { get; set; }
        }
    }

    //Многие ко многим
    class Many_To_Many
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }

            //Навигационное свойство
            public List<Topic> Topics { get; set; }
        }

        public class Topic
        {
            public int Id { get; set; }
            public string Name { get; set; }

            //Навигационное свойство
            public List<User> Users { get; set; }
        }
    }
}
