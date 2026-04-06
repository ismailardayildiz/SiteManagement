using SiteManagement.Core.Entities;
using SiteManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Payment : EntityBase
    {
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public Guid DueId { get; set; }
        public Guid PayerId { get; set; }

        public Due Due { get; set; }
        public AppUser Payer { get; set; }
    }
}
