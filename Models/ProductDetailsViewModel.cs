using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Models
{
    public class ProductDetailsViewModel
    {
        public int Quantity { get; set; }
        public Product Prooduct { get; set; }
    }
}
