using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModel.Category;

namespace CommonModel.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Content { get; set; }
        public string? Uses { get; set; }
        public string? Describe { get; set; }
        public string Image { get; set; }
        public string? Using { get; set; }
        public string? Contraindication { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }     
        public string? CategoryName { get; set; }
    }
}
