using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ECommerceApp.Models
{
    public class Product
    {
        //test
        //test2
        
        [Key]
        public int Id { get; init; }
        [Required]
        [MaxLength(255)]
        public string Name { get; init; }
        [Required]
        public string Description { get; init; }
        [Required]
        public decimal Price { get; init; }
        [Required]
        public int StockQuantity { get; init; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; init; }
        [Required]
        public string ImageURL { get; init; }

        public List<OrderItem> OrderItems { get; init; } = new List<OrderItem>();
        public List<Review> Reviews { get; init; } = new List<Review>();
        public Category Category { get; init; }
    }
}
