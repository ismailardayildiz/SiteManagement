using Microsoft.AspNetCore.Identity;
using SiteManagement.Entity.DTOs.Users;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<UserUpdateDto> GetUserForUpdateAsync(Guid userId);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<IdentityResult> DeleteUserAsync(Guid userId);
    }
}
