using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        public User User { get; set; }
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Payment Payment { get; set; }
    }
}
