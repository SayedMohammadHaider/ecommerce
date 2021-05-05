using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectECommerce.Models.DB
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
