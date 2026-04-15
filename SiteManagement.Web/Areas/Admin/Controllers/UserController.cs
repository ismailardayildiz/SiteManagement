// SiteManagement.Web/Areas/Admin/Controllers/UserController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteManagement.Entity.DTOs.Users;
using SiteManagement.Entity.Enums;
using SiteManagement.Service.Helpers.Images;
using SiteManagement.Service.Services.Abstractions;
using SiteManagement.Web.Helpers.Images;
using System;
using System.Threading.Tasks;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageHelper _imageHelper;

        public UserController(IUserService userService, IImageHelper imageHelper)
        {
            _userService = userService;
            _imageHelper = imageHelper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersWithRoleAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _userService.GetAllRolesAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            return PartialView("Add", new UserAddDto());
        }

        [HttpPost]
        [HttpPost]
        // 3. [FromForm] EKLENDİ
        public async Task<IActionResult> Add([FromForm] UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                // 4. RESİM KAYDETME KODLARI EKLENDİ
                if (userAddDto.ProfileImage != null && userAddDto.ProfileImage.Length > 0)
                {
                    var imageResult = await _imageHelper.Upload(
                        $"{userAddDto.FirstName}{userAddDto.LastName}",
                        userAddDto.ProfileImage,
                        ImageType.User);

                    // Oluşan dosya yolunu DTO'ya veriyoruz ki UserService veritabanına yazsın
                    userAddDto.ImagePath = imageResult.FullName;
                }

                var result = await _userService.CreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            var roles = await _userService.GetAllRolesAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            return PartialView("Add", userAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userService.GetUserForUpdateAsync(userId);
            if (user == null) return NotFound();

            var roles = await _userService.GetAllRolesAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            return PartialView("Update", user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                // Eğer yeni bir fotoğraf seçilmişse
                if (userUpdateDto.ProfileImage != null)
                {
                    // 1. Varsa eski fotoğrafı sunucudan fiziksel olarak sil
                    if (!string.IsNullOrEmpty(userUpdateDto.ImagePath))
                    {
                        _imageHelper.Delete(userUpdateDto.ImagePath);
                    }

                    // 2. Yeni fotoğrafı yükle
                    var imageUpload = await _imageHelper.Upload(
                    $"{userUpdateDto.FirstName}{userUpdateDto.LastName}",
                    userUpdateDto.ProfileImage, ImageType.User);
                    // 3. Yeni yolu DTO'ya ata
                    userUpdateDto.ImagePath = imageUpload.FullName;
                }

                var result = await _userService.UpdateUserAsync(userUpdateDto);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            var roles = await _userService.GetAllRolesAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            return PartialView("Update", userUpdateDto);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid userId)
        {
            var user = await _userService.GetUserForUpdateAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return PartialView("Detail", user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }
    }
}