using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectECommerce.Models.DB
{
    public partial class OrderDetail
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
