namespace Domain.Entities
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public long Population { get; set; }
        public List<User> Users { get; set; }
    }
}
