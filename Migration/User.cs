namespace EF_Migration
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        //Внешний ключ
        public int CompanyId { get; set; }
        //Навигационное свойство
        public Company Company { get; set; }
    }
}
