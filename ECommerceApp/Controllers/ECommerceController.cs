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

        [HttpPost]
        [Route("orders/place_order")]
        public async Task<IActionResult> PlaceOrder(OrderPaymentDTO orderPaymentDTO)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    Order orderInput = new Order
                    {
                        Email = orderPaymentDTO.Email,
                        TotalPrice = orderPaymentDTO.TotalPrice,
                        OrderDate = orderPaymentDTO.OrderDate,
                        Address = orderPaymentDTO.Address,
                        PaymentId = orderPaymentDTO.PaymentId,
                    };

                    _db.Orders.Add(orderInput);
                    await _db.SaveChangesAsync();

                    Payment paymentInput = new Payment
                    {
                        OrderId = orderInput.Id,
                        PaymentMethod = orderPaymentDTO.PaymentMethod,
                        Status = orderPaymentDTO.Status,
                        CardName= orderPaymentDTO.CardName,
                        CardCVV = orderPaymentDTO.CardCVV,
                        CardExpirationDate = orderPaymentDTO.CardExpirationDate,
                        CardNumber= orderPaymentDTO.CardNumber,
                        
                    };

                    _db.Payments.Add(paymentInput);
                    await _db.SaveChangesAsync();

                    orderInput.PaymentId = paymentInput.Id;
                    _db.Orders.Update(orderInput);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Created("orders/place_order" + orderInput.Id, new {Message = "Success"});
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
