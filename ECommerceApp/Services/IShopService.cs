using ECommerceApp.DataTransferObjects;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Services
{
    public interface IShopService
    {
        Task<OrderPaymentDTO> PlaceOrder(OrderPaymentDTO orderPaymentDTO);
        Task <ProductDTO[]> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<OrderDTO[]> GetAllOrders();
        Task<PaymentDTO[]> GetAllPayments();
    }
}
