using System;
using System.Collections.Generic;

namespace ManagementStocuri.Models.DBObjects
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Idproduct { get; set; }
        public Guid Idsupplier { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int PriceBuy { get; set; }
        public int PriceSell { get; set; }

        public virtual Supplier IdsupplierNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
