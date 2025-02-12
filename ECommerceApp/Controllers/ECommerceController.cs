using ECommerceApp.Data;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using ECommerceApp.DataTransferObjects;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerceApp.Controllers
{
    //test
    [ApiController]
    [Route("[controller]")]
    public class ECommerceController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public ECommerceController(ApplicationDbContext db) 
        {
            _db = db;
            
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _db.Users;
            return Ok(users);
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            List<ProductDTO> response = _db.Products.ProjectToType<ProductDTO>().ToList();

            
            return Ok(response);
        }

        [HttpGet("GetProducts/Details/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productById = await _db.Products.FindAsync(id);

            ProductDTO response = productById.Adapt<ProductDTO>();
            return Ok(response);
        }
    }
}
