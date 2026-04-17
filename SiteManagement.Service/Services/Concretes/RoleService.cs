using Microsoft.AspNetCore.Identity;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Concretes
{
    public class RoleService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public RoleService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IdentityResult> AssignRoleToUserAsync(Guid userId, Guid roleId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });

            var currentRoles = await userManager.GetRolesAsync(user);
            var removeResult = await userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!removeResult.Succeeded) return removeResult;

            var newRole = await roleManager.FindByIdAsync(roleId.ToString());
            if (newRole != null)
            {
                return await userManager.AddToRoleAsync(user, newRole.Name);
            }

            return IdentityResult.Failed(new IdentityError { Description = "Atanmak istenen rol bulunamadı." });
        }
    }
}
