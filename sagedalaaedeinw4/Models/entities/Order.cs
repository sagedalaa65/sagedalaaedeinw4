using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sagedalaaedeinw4.Models.entities
{
    public class Order
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
