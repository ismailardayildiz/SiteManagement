using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteManagement.Service.Helpers.Images;
using SiteManagement.Service.Services.Abstractions;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController
    {
        private readonly IUserService _userService;

        public RoleController(IUserService userService,)
        {
            _userService = userService;
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
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }

            var result = await _userService.AssignRoleToUserAsync(Id, RoleId);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            }

            return RedirectToAction("Index", "Role", new { Area = "Admin" });
        }
    }
}
