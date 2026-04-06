using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class RoleSeed
    {
        public static readonly Guid AdminRoleId = Guid.Parse("813C1780-E84A-4992-9676-2DA6E6BB38DF");
        public static readonly Guid ManagerRoleId = Guid.Parse("8407BEB3-E2B8-483D-B7C5-F159327AA74B");
        public static readonly Guid OwnerRoleId = Guid.Parse("44A9B0B3-9DF5-4B85-83AC-608ABFE46207");
        public static readonly Guid TenantRoleId = Guid.Parse("45F843CB-D1E5-4A6B-AFA3-3AB105D3B159");
        public static readonly Guid EmployeeRoleId = Guid.Parse("066247BA-CA2C-4554-9311-BD96D8658923");

        public static readonly IEnumerable<AppRole> Data = new List<AppRole>
        {

    new AppRole
            {
                Id             = AdminRoleId,
                Name           = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },

            new AppRole
            {
                Id               = ManagerRoleId,
                Name             = "Manager",
                NormalizedName   = "MANAGER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new AppRole
            {
                Id               = OwnerRoleId,
                Name             = "Owner",
                NormalizedName   = "OWNER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new AppRole
            {
                Id               = TenantRoleId,
                Name             = "Tenant",
                NormalizedName   = "TENANT",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new AppRole
            {
                Id               = EmployeeRoleId,
                Name             = "Employee",
                NormalizedName   = "EMPLOYEE",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };
    }

}
