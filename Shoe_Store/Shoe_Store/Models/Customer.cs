using System;
using System.Collections.Generic;

namespace Shoe_Store.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
