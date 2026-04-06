using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class UserRoleSeed
    {
        public static readonly IEnumerable<IdentityUserRole<Guid>> Data = new List<IdentityUserRole<Guid>>
        {
            new IdentityUserRole<Guid>
            {
                UserId = UserSeed.AdminId,
                RoleId = RoleSeed.AdminRoleId
            },
            new IdentityUserRole<Guid>
            {
                UserId = UserSeed.ManagerId,
                RoleId = RoleSeed.ManagerRoleId
            },
            new IdentityUserRole<Guid>
            {
                UserId = UserSeed.Owner1Id,
                RoleId = RoleSeed.OwnerRoleId
            },
            new IdentityUserRole<Guid>
            {
                UserId = UserSeed.Owner2Id,
                RoleId = RoleSeed.OwnerRoleId
            },
            new IdentityUserRole<Guid>
            {
                UserId = UserSeed.Tenant1Id,
                RoleId = RoleSeed.TenantRoleId
            },
            new IdentityUserRole<Guid>
            {
                UserId = UserSeed.Tenant2Id,
                RoleId = RoleSeed.TenantRoleId
            }
        };
    }
}
