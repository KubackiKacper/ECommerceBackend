using ECommerceApp.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Services
{
    public interface IPlaceOrderService
    {
       Task<OrderPaymentDTO> PlaceOrderAsync(OrderPaymentDTO orderPaymentDTO);
    }
}
