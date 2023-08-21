using System;
using System.Collections.Generic;

namespace Shoe_Store.Models
{
    public partial class Provider
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public DateTime? ProvideDate { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
