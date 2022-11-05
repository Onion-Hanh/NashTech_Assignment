using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModel.Category
{
    public class CategoryAminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public bool Status { get; set; }
    }
}
