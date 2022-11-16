using EF_Console.Models.Conf;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Console.Models
{
    [EntityTypeConfiguration(typeof(CountryConf))]      //ещё один способ применения кофигураций, вынесеных в отдельный класс
    [NotMapped]     //Исключить сущность из модели
    [Table("Example")]      //Задать имя для создаваемой таблицы
    [Index("Index", IsUnique = true, Name = "Index_Index")]     //Создание уникального именованного индекса     Index("Index", "Id") - индекс для нобора свойств
    public class Country
    {
        string field;
        int prop;

        [Key]   //PK
        [Required] //Not Null
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //Вкл. автогенерацию значений (автоикремент)   
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]   //Отключить автоматическую генерацию значений
        public int OtherId { get; set; }
        public int Index { get; set; }
        public DateTime Date { get; set; }

        [Column("Name")]    //Имя для колонки
        [MinLength(1)]      //Минимальная длина значения
        [MaxLength(255)]    //Максимальная длина свойства
        public string Name { get; set; }
        public int Prop => prop;

        [NotMapped]
        public Company? Company { get; set; }
    }
}
