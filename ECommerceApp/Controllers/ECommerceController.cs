using ECommerceApp.Data;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using ECommerceApp.DataTransferObjects;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;


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
        
        [HttpGet]
        [Route("products")]
        public IActionResult GetProducts()
        {
            try
            {
                List<ProductDTO> response = _db.Products.Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    ImageURL = p.ImageURL
                }).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
        [HttpGet]
        [Route("products/details/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            Product productById = await _db.Products.FindAsync(id);
            try
            {

                if (productById!=null)
                {
                    ProductDTO response = productById.Adapt<ProductDTO>();
                    return Ok(response);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult GetOrders()
        {
            try
            {
                List<OrderDTO> response = _db.Orders.Select(o => new OrderDTO
                {
                    Id = o.Id,
                    Email = o.Email,
                    TotalPrice = o.TotalPrice,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    PaymentId = o.PaymentId,
                }).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost]
        [Route("orders/place_order")]
        public IActionResult PlaceOrder(OrderDTO orderDTO)
        {
            try
            {
                var userInput = new Order
                {
                    Email = orderDTO.Email,
                    TotalPrice = orderDTO.TotalPrice,
                    OrderDate = orderDTO.OrderDate,
                    Status = orderDTO.Status,
                    PaymentId = orderDTO.PaymentId,
                };

                if (userInput != null)
                {
                    _db.Orders.Add(userInput);
                    _db.SaveChanges();
                }
                
                return Created("orders/place_order" + userInput.Id, new {Message = "Success"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
