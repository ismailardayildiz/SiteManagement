using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class AnnouncementSeed
    {
        public static readonly IEnumerable<Announcement> Data = new List<Announcement>
        {
            new Announcement
            {
                Id          = Guid.Parse("126C039B-8731-439F-96C5-0F06B7EDA003"),
                Title       = "Ocak Ayı Aidat Bildirimi",
                Content     = "Ocak 2024 dönemi aidat ödemeleri 31 Ocak'a kadar yapılmalıdır.",
                SiteId      = SiteSeed.Site1Id,
                CreatedById = UserSeed.ManagerId,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 2),
                IsDeleted   = false
            },
            new Announcement
            {
                Id          = Guid.Parse("275EADCC-2F61-41B7-82A6-80C7BB24A85D"),
                Title       = "Su Kesintisi Duyurusu",
                Content     = "15 Ocak 2024 tarihinde 09:00-17:00 saatleri arasında bakım nedeniyle su kesintisi yaşanacaktır.",
                SiteId      = SiteSeed.Site1Id,
                CreatedById = UserSeed.ManagerId,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 10),
                IsDeleted   = false
            },
            new Announcement
            {
                Id          = Guid.Parse("D4BE6E28-D3CD-4F06-AFC0-1E3AFED68CFF"),
                Title       = "Genel Kurul Toplantısı",
                Content     = "20 Ocak 2024 Cumartesi saat 14:00'te site toplantı salonunda genel kurul yapılacaktır.",
                SiteId      = SiteSeed.Site2Id,
                CreatedById = UserSeed.ManagerId,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 5),
                IsDeleted   = false
            }
        };
    }
}
