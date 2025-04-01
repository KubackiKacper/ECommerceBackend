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

namespace ECommerceApp.Services
{
    public class ShopService : IShopService
    {
        private readonly ApplicationDbContext _context;
        public ShopService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDTO[]> GetAllProducts()
        {
            ProductDTO[] response = await _context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CategoryId = p.CategoryId,
                ImageURL = p.ImageURL
            }).ToArrayAsync();
            return response;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            Product response = await _context.Products.FindAsync(id);
            ProductDTO result = new ProductDTO
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
                Price = response.Price,
                StockQuantity = response.StockQuantity,
                CategoryId = response.CategoryId,
                ImageURL = response.ImageURL
            };
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<OrderDTO[]> GetAllOrders()
        {
            OrderDTO[] response = await _context.Orders.Select(o => new OrderDTO
            {
                OrderId = o.Id,
                Email = o.Email,
                TotalPrice = o.TotalPrice,
                OrderDate = o.OrderDate,
                Address = o.Address,
                PaymentId = o.PaymentId,
            }).ToArrayAsync();

            return response;
        }
        public async Task<OrderPaymentDTO> PlaceOrder(OrderPaymentDTO orderPaymentDTO)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
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

                    _context.Orders.Add(orderInput);
                    await _context.SaveChangesAsync();

                    Payment paymentInput = new Payment
                    {
                        OrderId = orderInput.Id,
                        PaymentMethod = orderPaymentDTO.PaymentMethod,
                        Status = orderPaymentDTO.Status,
                        CardName = orderPaymentDTO.CardName,
                        CardCVV = orderPaymentDTO.CardCVV,
                        CardExpirationDate = orderPaymentDTO.CardExpirationDate,
                        CardNumber = orderPaymentDTO.CardNumber,

                    };

                    _context.Payments.Add(paymentInput);
                    await _context.SaveChangesAsync();

                    orderInput.PaymentId = paymentInput.Id;
                    _context.Orders.Update(orderInput);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return new OrderPaymentDTO
                    {
                        Email = orderPaymentDTO.Email,
                        TotalPrice = orderPaymentDTO.TotalPrice,
                        OrderDate = orderPaymentDTO.OrderDate,
                        Address = orderPaymentDTO.Address,
                        PaymentId = orderPaymentDTO.PaymentId,
                        OrderId = orderPaymentDTO.OrderId,
                        PaymentMethod = orderPaymentDTO.PaymentMethod,
                        Status = orderPaymentDTO.Status,
                        CardName = orderPaymentDTO.CardName,
                        CardCVV = orderPaymentDTO.CardCVV,
                        CardExpirationDate = orderPaymentDTO.CardExpirationDate,
                        CardNumber = orderPaymentDTO.CardNumber,
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return null;
                }
            }
        }

        public async Task<PaymentDTO[]> GetAllPayments()
        {
            PaymentDTO[] response = await _context.Payments.Select(p => new PaymentDTO
            {
                PaymentId = p.Id,
                OrderId = p.OrderId,
                PaymentMethod = p.PaymentMethod,
                Status = p.Status,
                CardName = p.CardName,
                CardCVV = p.CardCVV,
                CardExpirationDate = p.CardExpirationDate,
                CardNumber = p.CardNumber,
            }).ToArrayAsync();
            return response;
        }
    }
}
