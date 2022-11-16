namespace EF_Migration
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Type { get; set; }

        public List<User> Users { get; set; }
    }
}
