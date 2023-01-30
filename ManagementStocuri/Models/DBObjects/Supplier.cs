using System;
using System.Collections.Generic;

namespace ManagementStocuri.Models.DBObjects
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public Guid Idsupplier { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Adress { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
