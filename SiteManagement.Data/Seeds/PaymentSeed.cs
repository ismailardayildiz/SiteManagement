using SiteManagement.Entity.Entities;
using SiteManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class PaymentSeed
    {
        public static readonly IEnumerable<Payment> Data = new List<Payment>
        {
            new Payment
            {
                Id            = Guid.Parse("8FA465D5-C762-43EE-B893-67E9E88F963E"),
                PaidAmount    = 750m,
                PaymentDate   = new DateTime(2024, 1, 15),
                PaymentStatus = PaymentStatus.Paid,
                PaymentMethod = "Bank Transfer",
                DueId         = DueSeed.Due1Id,
                PayerId       = UserSeed.Owner1Id,
                CreatedBy     = "seed",
                CreatedDate   = new DateTime(2024, 1, 15),
                IsDeleted     = false
            },
            new Payment
            {
                Id            = Guid.Parse("3A231A48-7119-475A-8DCF-C62EC7CAC700"),
                PaidAmount    = 750m,
                PaymentDate   = new DateTime(2024, 2, 3),
                PaymentStatus = PaymentStatus.Overdue,
                PaymentMethod = "Cash",
                DueId         = DueSeed.Due2Id,
                PayerId       = UserSeed.Tenant1Id,
                CreatedBy     = "seed",
                CreatedDate   = new DateTime(2024, 2, 3),
                IsDeleted     = false
            }
        };
    }
}
