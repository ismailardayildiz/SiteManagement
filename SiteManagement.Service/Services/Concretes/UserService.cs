using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Entity.DTOs.Users;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SiteManagement.Service.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = _mapper.Map<List<UserDto>>(users);

            foreach (var userDto in userDtos)
            {
                var user = await _userManager.FindByIdAsync(userDto.Id.ToString());
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Role = string.Join(", ", roles);
            }

            return userDtos;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var user = new AppUser
            {
                FirstName = userAddDto.FirstName,
                LastName = userAddDto.LastName,
                Email = userAddDto.Email,
                UserName = userAddDto.Email,
                PhoneNumber = userAddDto.PhoneNumber,

                ImagePath = userAddDto.ImagePath
            };

            var result = await _userManager.CreateAsync(user, userAddDto.Password);
            if (result.Succeeded)
            {
                var role = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                if (role != null)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
            }

            return result;
        }

        public async Task<UserUpdateDto> GetUserForUpdateAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;

            var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Any())
            {
                var role = await _roleManager.FindByNameAsync(roles.First());
                userUpdateDto.RoleId = role.Id;
            }

            return userUpdateDto;
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });

            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.Email = userUpdateDto.Email;
            user.UserName = userUpdateDto.Email;
            user.PhoneNumber = userUpdateDto.PhoneNumber;

            if (!string.IsNullOrEmpty(userUpdateDto.ImagePath))
            {
                user.ImagePath = userUpdateDto.ImagePath;
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

                var newRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                if (newRole != null)
                {
                    await _userManager.AddToRoleAsync(user, newRole.Name);
                }
            }

            return updateResult;
        }

        public async Task<IdentityResult> DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });

            return await _userManager.DeleteAsync(user);
        }
    }
}