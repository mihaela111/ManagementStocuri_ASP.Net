namespace ManagementStocuri.Models
{
    public class ProductModel
    {
        public Guid IDProduct { get; set; }
        public Guid IDSupplier { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int PriceBuy { get; set; }
        public int PriceSell { get; set; }
    }
}
