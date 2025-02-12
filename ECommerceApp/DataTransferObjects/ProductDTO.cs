using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
namespace ECommerceApp.DataTransferObjects
{
    public class ProductDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public string ImageURL { get; set; }
    }
}
