using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Dues
{
    public class DueListDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }

        // Hangi daireye ait olduğunu göstermek için
        public Apartment Apartment { get; set; }

        // Ödeme durumunu hesaplamak için ödemeleri de çekiyoruz
        public ICollection<Payment> Payments { get; set; }
    }
}
