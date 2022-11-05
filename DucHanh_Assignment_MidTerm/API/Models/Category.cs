namespace API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public bool Status { get; set; }
        public List<Product> products { get; set; }
    }
}
