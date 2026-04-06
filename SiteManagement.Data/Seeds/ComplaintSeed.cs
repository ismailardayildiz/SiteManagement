using SiteManagement.Entity.Entities;
using SiteManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class ComplaintSeed
    {
        public static readonly IEnumerable<Complaint> Data = new List<Complaint>
        {
            new Complaint
            {
                Id          = Guid.Parse("617015B4-00B8-4BAC-84EA-F1D64DCBFD15"),
                Title       = "Asansör Arızası",
                Description = "A Blok asansörü 3 gündür çalışmıyor, lütfen en kısa sürede tamir edilsin.",
                Status      = ComplaintStatus.UnderReview,
                UserId      = UserSeed.Owner1Id,
                ApartmentId = ApartmentSeed.Apt1Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 8),
                IsDeleted   = false
            },
            new Complaint
            {
                Id          = Guid.Parse("A37349EF-CFCE-4DD1-974B-39A6C673AAB3"),
                Title       = "Otopark Işıkları",
                Description = "Kapalı otoparkın giriş katındaki aydınlatmalar çalışmıyor.",
                Status      = ComplaintStatus.Pending,
                UserId      = UserSeed.Tenant1Id,
                ApartmentId = ApartmentSeed.Apt2Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 12),
                IsDeleted   = false
            },
            new Complaint
            {
                Id          = Guid.Parse("E4CF0EB7-9930-4A38-BCDA-82936CB82CFA"),
                Title       = "Gürültü Şikayeti",
                Description = "Üst daireden gece geç saatlerde gürültü gelmektedir.",
                Status      = ComplaintStatus.Resolved,
                UserId      = UserSeed.Owner2Id,
                ApartmentId = ApartmentSeed.Apt3Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 6),
                IsDeleted   = false
            }
        };
    }
}
