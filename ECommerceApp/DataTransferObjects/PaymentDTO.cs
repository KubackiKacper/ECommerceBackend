using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }

        public int OrderId { get; set; }

        public string PaymentMethod { get; set; }

        public string Status { get; set; }

        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardCVV { get; set; }
        public DateTime CardExpirationDate { get; set; }

    }


}
