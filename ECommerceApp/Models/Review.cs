using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]

        public string Comment { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
