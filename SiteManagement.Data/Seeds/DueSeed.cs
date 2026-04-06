using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class DueSeed
    {
        public static readonly Guid Due1Id = Guid.Parse("B34E20B9-7F7C-49E4-964A-324FABB52F05");
        public static readonly Guid Due2Id = Guid.Parse("9873D671-211A-4C52-A98C-39E7F8AFBA30");
        public static readonly Guid Due3Id = Guid.Parse("BAA7A46E-8745-4525-ABFA-512CEB5E20E6");

        public static readonly IEnumerable<Due> Data = new List<Due>
        {
            new Due
            {
                Id          = Due1Id,
                Year        = 2024,
                Month       = 1,
                Amount      = 750m,
                DueDate     = new DateTime(2024, 1, 31),
                ApartmentId = ApartmentSeed.Apt1Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted   = false
            },
            new Due
            {
                Id          = Due2Id,
                Year        = 2024,
                Month       = 1,
                Amount      = 750m,
                DueDate     = new DateTime(2024, 1, 31),
                ApartmentId = ApartmentSeed.Apt2Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted   = false
            },
            new Due
            {
                Id          = Due3Id,
                Year        = 2024,
                Month       = 1,
                Amount      = 850m,
                DueDate     = new DateTime(2024, 1, 31),
                ApartmentId = ApartmentSeed.Apt3Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted   = false
            }
        };
    }
}
