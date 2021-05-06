using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectECommerce.Models.DB
{
    public partial class Order
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? UserId { get; set; }
        public int? Quantity { get; set; }
        public long? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
