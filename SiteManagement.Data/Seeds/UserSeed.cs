using Microsoft.AspNetCore.Identity;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class UserSeed
    {
        public static readonly Guid AdminId = Guid.Parse("C6B6CE5A-93AC-44D1-936B-ED80B6F9B04F");
        public static readonly Guid ManagerId = Guid.Parse("CC25344A-3173-4459-9AD4-D2C7D7A5AC13");
        public static readonly Guid Owner1Id = Guid.Parse("44010978-E210-4DB8-81E9-6F191695953B");
        public static readonly Guid Owner2Id = Guid.Parse("C725E0E7-D8C1-4AC7-B9AC-D580CD22AA1D");
        public static readonly Guid Tenant1Id = Guid.Parse("E60285CB-58DF-4960-BA9F-D5BBD5116195");
        public static readonly Guid Tenant2Id = Guid.Parse("589DA78A-0FD1-4FDF-BDDE-4BF626B0B2DF");

        private static string Hash(string password)
        {
            var hasher = new PasswordHasher<AppUser>();
            return hasher.HashPassword(null!, password);
        }

        public static readonly IEnumerable<AppUser> Data = new List<AppUser>
        {
     new AppUser
            {
                Id                 = AdminId,
                FirstName          = "System",
                LastName           = "Admin",
                UserName           = "admin",
                NormalizedUserName = "ADMIN",
                Email              = "admin@siteyonetim.com",
                NormalizedEmail    = "ADMIN@SITEYONETIM.COM",
                EmailConfirmed     = true,
                PasswordHash       = Hash("Admin123!"),
                SecurityStamp      = Guid.NewGuid().ToString(),
                ConcurrencyStamp   = Guid.NewGuid().ToString()
            },
            new AppUser
            {
                Id                   = ManagerId,
                FirstName            = "Ahmet",
                LastName             = "Yılmaz",
                UserName             = "ahmet.yilmaz",
                NormalizedUserName   = "AHMET.YILMAZ",
                Email                = "ahmet@siteyonetim.com",
                NormalizedEmail      = "AHMET@SITEYONETIM.COM",
                EmailConfirmed       = true,
                PasswordHash         = Hash("Manager123!"),
                SecurityStamp        = Guid.NewGuid().ToString(),
                ConcurrencyStamp     = Guid.NewGuid().ToString()
            },
            new AppUser
            {
                Id                   = Owner1Id,
                FirstName            = "Mehmet",
                LastName             = "Kaya",
                UserName             = "mehmet.kaya",
                NormalizedUserName   = "MEHMET.KAYA",
                Email                = "mehmet@siteyonetim.com",
                NormalizedEmail      = "MEHMET@SITEYONETIM.COM",
                EmailConfirmed       = true,
                PasswordHash         = Hash("Owner123!"),
                SecurityStamp        = Guid.NewGuid().ToString(),
                ConcurrencyStamp     = Guid.NewGuid().ToString()
            },
            new AppUser
            {
                Id                   = Owner2Id,
                FirstName            = "Ayşe",
                LastName             = "Demir",
                UserName             = "ayse.demir",
                NormalizedUserName   = "AYSE.DEMIR",
                Email                = "ayse@siteyonetim.com",
                NormalizedEmail      = "AYSE@SITEYONETIM.COM",
                EmailConfirmed       = true,
                PasswordHash         = Hash("Owner123!"),
                SecurityStamp        = Guid.NewGuid().ToString(),
                ConcurrencyStamp     = Guid.NewGuid().ToString()
            },
            new AppUser
            {
                Id                   = Tenant1Id,
                FirstName            = "Ali",
                LastName             = "Çelik",
                UserName             = "ali.celik",
                NormalizedUserName   = "ALI.CELIK",
                Email                = "ali@siteyonetim.com",
                NormalizedEmail      = "ALI@SITEYONETIM.COM",
                EmailConfirmed       = true,
                PasswordHash         = Hash("Tenant123!"),
                SecurityStamp        = Guid.NewGuid().ToString(),
                ConcurrencyStamp     = Guid.NewGuid().ToString()
            },
            new AppUser
            {
                Id                   = Tenant2Id,
                FirstName            = "Fatma",
                LastName             = "Şahin",
                UserName             = "fatma.sahin",
                NormalizedUserName   = "FATMA.SAHIN",
                Email                = "fatma@siteyonetim.com",
                NormalizedEmail      = "FATMA@SITEYONETIM.COM",
                EmailConfirmed       = true,
                PasswordHash         = Hash("Tenant123!"),
                SecurityStamp        = Guid.NewGuid().ToString(),
                ConcurrencyStamp     = Guid.NewGuid().ToString()
            }
        };
    }

}
