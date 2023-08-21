using System;
using System.Collections.Generic;

namespace Shoe_Store.Models
{
    public partial class Product
    {
        public Product()
        {
            Customers = new HashSet<Customer>();
            Providers = new HashSet<Provider>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? InStock { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
    }
}
