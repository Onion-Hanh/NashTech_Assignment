namespace API.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public bool? Status { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
