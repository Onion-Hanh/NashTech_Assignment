using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModel.Product
{
    public class ProductAdminDTO
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
        public double ImportPrice { get; set; }
        public double Price { get; set; }
        public string CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
