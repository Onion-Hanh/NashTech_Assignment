using CommonModel.Product;
using CommonModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModel.Rating
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int ProductId { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public RatingDTO() 
        {

        }
    }
}
