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
       
        
        [StringLength(100, ErrorMessage ="Name is too long, max. length 100")]
        public string Name { get; set; }
      
        
        [StringLength(1000, ErrorMessage = "Description is too long, max. length 1000")]
        public string Description { get; set; }
        public int Discount { get; set; }
    }
}
