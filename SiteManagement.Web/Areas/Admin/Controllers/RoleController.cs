using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteManagement.Service.Helpers.Images;
using SiteManagement.Service.Services.Abstractions;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller // Controller sınıfından kalıtım alındı
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService; // IRoleService eklendi

        public RoleController(IUserService userService, IRoleService roleService) // Virgül hatası düzeltildi
        {
            _userService = userService;
            _roleService = roleService;
        }

        // Kullanıcıları ve mevcut rollerini listeleyecek sayfa
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersWithRoleAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AccessRole(Guid userId)
        {
            var user = await _userService.GetUserForUpdateAsync(userId);
            if (user == null) return NotFound();

            var roles = await _userService.GetAllRolesAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name", user.RoleId);

            return PartialView("AccessRole", user);
        }

        [HttpPost]
        public async Task<IActionResult> AccessRole(Guid Id, Guid RoleId)
        {
            if (RoleId == Guid.Empty)
            {
                ModelState.AddModelError("", "Lütfen geçerli bir rol seçiniz.");
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            }

            // _userService yerine doğru servis olan _roleService kullanıldı
            var result = await _roleService.AssignRoleToUserAsync(Id, RoleId);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            }

            return RedirectToAction("Index", "Role", new { Area = "Admin" });
        }
    }
}