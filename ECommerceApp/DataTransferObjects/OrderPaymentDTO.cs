using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.DataTransferObjects
{
    public class OrderPaymentDTO
    {
        public int OrderId { get; set; }
        public string Email { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public string Address { get; set; }

        public int PaymentId { get; set; }

        public string PaymentMethod { get; set; }

        public string Status { get; set; }

        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardCVV { get; set; }
        public DateTime CardExpirationDate { get; set; }
    }
}
