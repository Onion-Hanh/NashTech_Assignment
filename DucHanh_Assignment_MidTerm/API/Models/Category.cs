namespace API.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        List<Product> products { get; set; }
    }
}
