using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModel.Catagory;

namespace CommonModel.Product
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
        public double Price { get; set; }
        public string CategoryID { get; set; }

    }
}
