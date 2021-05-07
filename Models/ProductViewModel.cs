using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CategoryName { get; set; }
    }
}
