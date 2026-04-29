using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Payments
{
    public class PaymentAddDto
    {
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string? PaymentMethod { get; set; } // Nakit, Kredi Kartı, EFT vb.
        public Guid DueId { get; set; }
        public Guid PayerId { get; set; } 
        public string? ApartmentInfo { get; set; }
        public decimal TotalDueAmount { get; set; }
    }
}
