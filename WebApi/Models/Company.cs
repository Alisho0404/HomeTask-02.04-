namespace WebApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
