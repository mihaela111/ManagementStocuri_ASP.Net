using System.ComponentModel.DataAnnotations;

namespace ManagementStocuri.Models
{
    public class OfferModel
    {
        public Guid IDOffer { get; set; }
       
        [DisplayFormat(DataFormatString="{0:MM/dd/yyy}")]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyy}")]
        [DataType(DataType.Date)]
        public DateTime ValidTo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
    }
}
