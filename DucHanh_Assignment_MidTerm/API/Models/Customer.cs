namespace API.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string Password { get; set; }
        public List<Rating> ratings { get; set; }
    }
}
