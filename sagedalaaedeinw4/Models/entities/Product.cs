using System.ComponentModel.DataAnnotations;

namespace sagedalaaedeinw4.Models.entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        [StringLength(50)]
        public string Category { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
