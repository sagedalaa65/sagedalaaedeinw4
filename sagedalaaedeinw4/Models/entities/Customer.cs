using System.ComponentModel.DataAnnotations;

namespace sagedalaaedeinw4.Models.entities
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int Phone { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public ICollection<Order>? Orders { get; set; }

    }
}
