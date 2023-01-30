using System;
using System.Collections.Generic;

namespace ManagementStocuri.Models.DBObjects
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Idcustomer { get; set; }
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Adress { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
