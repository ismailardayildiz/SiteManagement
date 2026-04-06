using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class VehicleSeed
    {
        public static readonly IEnumerable<Vehicle> Data = new List<Vehicle>
        {
            new Vehicle
            {
                Id           = Guid.Parse("35CE1FB0-D036-422D-9C95-985C67E1CBAF"),
                LicensePlate = "34 ABC 123",
                UserId       = UserSeed.Owner1Id,
                ApartmentId  = ApartmentSeed.Apt1Id,
                CreatedBy    = "seed",
                CreatedDate  = new DateTime(2024, 1, 1),
                IsDeleted    = false
            },
            new Vehicle
            {
                Id           = Guid.Parse("44A37F57-867C-42C6-AC42-10815B4992E1"),
                LicensePlate = "06 XYZ 456",
                UserId       = UserSeed.Tenant1Id,
                ApartmentId  = ApartmentSeed.Apt2Id,
                CreatedBy    = "seed",
                CreatedDate  = new DateTime(2024, 1, 1),
                IsDeleted    = false
            }
        };
    }
}
