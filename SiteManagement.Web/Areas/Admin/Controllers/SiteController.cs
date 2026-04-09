using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Sites;
using SiteManagement.Entity.DTOs.Users;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SiteController : Controller
    {
        private readonly ISiteService siteService;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public SiteController(ISiteService siteService, IUnitOfWork unitOfWork, UserManager<AppUser> userManager,IMapper mapper)
        {
            this.siteService = siteService;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var sites = await siteService.GetAllSitesWithManagerNameAsync();
            return View(sites);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(SiteAddDto siteAddDto)
        {
        
            if (ModelState.IsValid)
            {
                var result = await siteService.CreateSiteWithManagerAsync(siteAddDto);

                if (result.Succeeded)
                {
                   
                    return RedirectToAction("Index", "Site", new { Area = "Admin" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

           
            return View(siteAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var site = await unitOfWork.GetRepository<Site>().GetAsync(x => x.Id == id, x => x.Manager);
            if (site == null) return NotFound();

            var map = mapper.Map<SiteUpdateDto>(site);
            var managers = await userManager.GetUsersInRoleAsync("Manager");
            map.Managers = managers.ToList();

            // Layoutsuz dönmek için PartialView kullanıyoruz
            return PartialView("Update", map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SiteUpdateDto siteUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await siteService.UpdateSiteWithManagerAsync(siteUpdateDto);
                if (result.Succeeded)
                {
                    // AJAX'a başarı mesajı dön
                    return Json(new { success = true });
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            var managers = await userManager.GetUsersInRoleAsync("Manager");
            siteUpdateDto.Managers = managers.ToList();

            // Hata varsa formu (Partial) tekrar dön
            return PartialView("Update", siteUpdateDto);
        }
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id) // Parametre ismi JS'deki 'id' ile aynı olmalı
        {
            await siteService.SafeDeleteSiteAsync(id);
            return Json(new { success = true, message = "Site başarıyla silindi." });
        }
    }
}
