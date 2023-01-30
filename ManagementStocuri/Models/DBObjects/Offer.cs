using System;
using System.Collections.Generic;

namespace ManagementStocuri.Models.DBObjects
{
    public partial class Offer
    {
        public Guid Idoffer { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public int Discount { get; set; }
    }
}
