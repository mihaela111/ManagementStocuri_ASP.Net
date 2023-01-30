using System.ComponentModel.DataAnnotations;

namespace ManagementStocuri.Models
{
    public class OrderModel
    {
        public Guid IDOrder { get; set; }
        public Guid IDCustomer { get; set; }
        public Guid IDProduct { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyy}")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public bool IsShipped { get; set; }

    }
}

