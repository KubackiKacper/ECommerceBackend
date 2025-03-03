using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.DataTransferObjects
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string Email { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public string Address { get; set; }

        public int PaymentId { get; set; }
    }
}
