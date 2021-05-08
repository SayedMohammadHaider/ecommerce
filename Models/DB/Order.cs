using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectECommerce.Models.DB
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
