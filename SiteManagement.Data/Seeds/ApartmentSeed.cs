using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class ApartmentSeed
    {
        public static readonly Guid Apt1Id = Guid.Parse("8C38F383-B67D-4F6C-8A75-FF57C58621B5");
        public static readonly Guid Apt2Id = Guid.Parse("B2823418-628C-4BCE-848A-4032ABB0FEAF");
        public static readonly Guid Apt3Id = Guid.Parse("825472E5-0820-46CD-9039-B1565BEFD726");
        public static readonly Guid Apt4Id = Guid.Parse("E5739A46-573E-4252-B610-060E0A4EF016");

        public static readonly IEnumerable<Apartment> Data = new List<Apartment>
        {
            new Apartment
            {
                Id              = Apt1Id,
                ApartmentNumber = "1",
                Floor           = 1,
                RoomCount       = 3,
                SquareMeters    = 120m,
                IsRented        = false,
                BlockId         = BlockSeed.Block1Id,
                SiteId          = SiteSeed.Site1Id,
                OwnerId         = UserSeed.Owner1Id,
                TenantId        = null,
                CreatedBy       = "seed",
                CreatedDate     = new DateTime(2024, 1, 1),
                IsDeleted       = false
            },
            new Apartment
            {
                Id              = Apt2Id,
                ApartmentNumber = "2",
                Floor           = 1,
                RoomCount       = 2,
                SquareMeters    = 90m,
                IsRented        = true,
                BlockId         = BlockSeed.Block1Id,
                SiteId          = SiteSeed.Site1Id,
                OwnerId         = UserSeed.Owner1Id,
                TenantId        = UserSeed.Tenant1Id,
                CreatedBy       = "seed",
                CreatedDate     = new DateTime(2024, 1, 1),
                IsDeleted       = false
            },
            new Apartment
            {
                Id              = Apt3Id,
                ApartmentNumber = "3",
                Floor           = 2,
                RoomCount       = 4,
                SquareMeters    = 150m,
                IsRented        = false,
                BlockId         = BlockSeed.Block2Id,
                SiteId          = SiteSeed.Site1Id,
                OwnerId         = UserSeed.Owner2Id,
                TenantId        = null,
                CreatedBy       = "seed",
                CreatedDate     = new DateTime(2024, 1, 1),
                IsDeleted       = false
            },
            new Apartment
            {
                Id              = Apt4Id,
                ApartmentNumber = "1",
                Floor           = 1,
                RoomCount       = 3,
                SquareMeters    = 110m,
                IsRented        = true,
                BlockId         = BlockSeed.Block3Id,
                SiteId          = SiteSeed.Site2Id,
                OwnerId         = UserSeed.Owner2Id,
                TenantId        = UserSeed.Tenant2Id,
                CreatedBy       = "seed",
                CreatedDate     = new DateTime(2024, 1, 1),
                IsDeleted       = false
            }
        };
    }
}
