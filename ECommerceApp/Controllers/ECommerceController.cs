using ECommerceApp.Data;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

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
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _db.Users;
            return Ok(users);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var users = _db.Products;
            return Ok(users);
        }
    }
}
