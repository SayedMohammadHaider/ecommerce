using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Models
{
    public class CartViewModel
    {
        public IEnumerable<Cart> Cart { get; set; }
        public IEnumerable<Address> Address { get; set; }
        public string SelectedAddress { get; set; }
    }
}
