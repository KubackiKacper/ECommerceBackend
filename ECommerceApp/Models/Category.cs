using System.ComponentModel.DataAnnotations;
namespace ECommerceApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
