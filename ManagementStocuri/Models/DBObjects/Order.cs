using System;
using System.Collections.Generic;

namespace ManagementStocuri.Models.DBObjects
{
    public partial class Order
    {
        public Guid Idorder { get; set; }
        public Guid Idcustomer { get; set; }
        public Guid Idproduct { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public bool IsShipped { get; set; }

        public virtual Customer IdcustomerNavigation { get; set; } = null!;
        public virtual Product IdproductNavigation { get; set; } = null!;
    }
}
