using ECommerceApp.Data;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace ECommerceApp.Controllers
{
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
        public async Task<IActionResult> Get()
        {
            var users = _db.Users;
            return Json(users);
        }
    }
}
