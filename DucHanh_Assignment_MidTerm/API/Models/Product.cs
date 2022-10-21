namespace API.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Uses { get; set; }
        public string Describe { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double ImportPrice { get; set; }
        public double Price { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public Category category { get; set; }
    }
}
