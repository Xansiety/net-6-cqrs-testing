using CQRSTesting.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CQRSTesting.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; } = 0.00M;

        [DataType(DataType.Date)]
        [DateInFuture]
        public DateTime DatePublished { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
    }
}
