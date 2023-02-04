using System.ComponentModel.DataAnnotations;

namespace ManagementStocuri.Models
{
    public class CustomerModel
    {
        public Guid IDCustomer { get; set; }

        [StringLength(100, ErrorMessage ="txet too long, max 100 char" )]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "txet too long, max 50 char")]
        public string Title { get; set; }

        [StringLength(100, ErrorMessage = "txet too long, max 15 char")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "txet too long, max 100 char")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "txet too long, max 250 char")]
        public string Adress { get; set; }
 
    }
}
