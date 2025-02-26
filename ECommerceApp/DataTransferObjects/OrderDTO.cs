using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.DataTransferObjects
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public int PaymentId { get; set; }
    }
}
