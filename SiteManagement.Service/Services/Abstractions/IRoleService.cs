using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IRoleService
    {
        Task<IdentityResult> AssignRoleToUserAsync(Guid userId, Guid roleId);
    }
}
