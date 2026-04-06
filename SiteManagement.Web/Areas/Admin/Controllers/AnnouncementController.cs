using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Announcements;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Manager")] // Sadece bu roller girebilir
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService announcementService;
        private readonly ISiteService siteService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public AnnouncementController(IAnnouncementService announcementService, ISiteService siteService, IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toast)
        {
            this.announcementService = announcementService;
            this.siteService = siteService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var announcements = await announcementService.GetAllAnnouncementsWithSiteAsync();
            return View(announcements);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var sites = await siteService.GetAllSitesWithManagerNameAsync();
            var model = new AnnouncementAddDto { Sites = sites };

            // Layoutsuz dönmek için PartialView kullanıyoruz
            return PartialView("Add", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AnnouncementAddDto announcementAddDto)
        {
            if (ModelState.IsValid)
            {
                await announcementService.CreateAnnouncementAsync(announcementAddDto);

                toast.AddSuccessToastMessage("Duyuru başarıyla eklendi.");

                return Json(new { success = true }); // AJAX kontrolü için JSON dönüyoruz
            }

            announcementAddDto.Sites = await siteService.GetAllSitesWithManagerNameAsync();
            return PartialView("Add", announcementAddDto);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var announcement = await unitOfWork.GetRepository<Announcement>().GetAsync(x => x.Id == id);
            var map = mapper.Map<AnnouncementUpdateDto>(announcement);
            map.Sites = await siteService.GetAllSitesWithManagerNameAsync();

            return PartialView("Update", map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AnnouncementUpdateDto announcementUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await announcementService.UpdateAnnouncementAsync(announcementUpdateDto);
                toast.AddSuccessToastMessage("Güncelleme başarılı");
                return Json(new { success = true });
            }

            // Hata varsa siteleri tekrar doldur ve partial dön
            announcementUpdateDto.Sites = await siteService.GetAllSitesWithManagerNameAsync();
            return PartialView("Update", announcementUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await announcementService.SafeDeleteAnnouncementAsync(id);
            return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
        }

    }
}
