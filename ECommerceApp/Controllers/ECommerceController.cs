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
    [ApiController]
    [Route("[controller]")]
    public class ECommerceController : Controller
    {
        private readonly IShopService _service;

        public ECommerceController(IShopService shopService) 
        { 
            _service = shopService;
        }
        
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var productResponse = await _service.GetAllProducts();
                return Ok(productResponse);
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
            try
            {
                var productByIdResponse = await _service.GetProductById(id);
                return Ok(productByIdResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var ordersResponse = await _service.GetAllOrders();
                return Ok(ordersResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("payments")]
        public async Task<IActionResult> GetPayments()
        {
            try
            {
                var paymentsResponse = await _service.GetAllPayments();              
                return Ok(paymentsResponse);
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
            var orderResponse = await _service.PlaceOrder(orderPaymentDTO);

            if (orderResponse == null)
            {
                return BadRequest("Order placement failed.");
            }

            return Ok(orderResponse);
        }
    }
}
