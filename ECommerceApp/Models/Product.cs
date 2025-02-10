using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerceApp.Models
{
    public class Product
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        public string ImageURL { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public Category Category { get; set; }
    }
}
