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
    public class PlaceOrderService : IPlaceOrderService
    {
        private readonly ApplicationDbContext _context;
        public PlaceOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderPaymentDTO> PlaceOrderAsync(OrderPaymentDTO orderPaymentDTO)
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
    }
}
