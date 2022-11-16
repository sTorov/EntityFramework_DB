using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Console.Models
{
    public class User
    {
        //Первичный ключ
        [Key]   //Необязательно
        public int Id { get; set; }
        [Column("Name")]    //Название колонки - необязательно
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        //Внешний ключ
        public int CompanyId { get; set; }
        //Навигационное свойство
        public Company Company { get; set; }
    }
}
