namespace CQRSTesting.Application.DTOs
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = 0.00M;
        public DateTime DatePublished { get; set; }
    }
}
