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
using ECommerceApp.Services;


namespace ECommerceApp.Controllers
{
    //test
    [ApiController]
    [Route("[controller]")]
    public class ECommerceController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IPlaceOrderService _placeOrder;

        public ECommerceController(ApplicationDbContext db, IPlaceOrderService placeOrder) 
        {
            _db = db;   
            _placeOrder = placeOrder;
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
                    OrderId = o.Id,
                    Email = o.Email,
                    TotalPrice = o.TotalPrice,
                    OrderDate = o.OrderDate,
                    Address = o.Address,
                    PaymentId = o.PaymentId,
                }).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet]
        [Route("payments")]
        public IActionResult GetPayments()
        {
            try
            {
                List<PaymentDTO> response = _db.Payments.Select(p => new PaymentDTO
                {
                    PaymentId = p.Id,
                    OrderId = p.OrderId,
                    PaymentMethod = p.PaymentMethod,
                    Status = p.Status,
                    CardName =p.CardName,
                    CardCVV = p.CardCVV,
                    CardExpirationDate =p.CardExpirationDate,
                    CardNumber=p.CardNumber,
                }).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        //test
        [HttpPost]
        [Route("orders/place_order")]
        public async Task<IActionResult> PlaceOrder(OrderPaymentDTO orderPaymentDTO)
        {
            var orderResponse = await _placeOrder.PlaceOrderAsync(orderPaymentDTO);

            if (orderResponse == null)
            {
                return BadRequest("Order placement failed.");
            }

            return Ok(orderResponse);
        }
    }
}
