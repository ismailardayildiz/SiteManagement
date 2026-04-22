using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteManagement.Entity.DTOs.Apartments;
using SiteManagement.Service.Services.Abstractions;
using SiteManagement.Service.Services.Concretes;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly ISiteService _siteService;
        private readonly IBlockService _blockService;
        private readonly IUserService userService;

        public ApartmentController(IApartmentService apartmentService, ISiteService siteService, IBlockService blockService, IUserService userService)
        {
            _apartmentService = apartmentService;
            _siteService = siteService;
            _blockService = blockService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var sites = await _siteService.GetAllSitesNonDeletedAsync();
            var users = await userService.GetAllUsersAsync();

            ViewBag.Sites = new SelectList(sites, "Id", "Name");
            ViewBag.Users = new SelectList(users, "Id", "FullName");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetApartments()
        {
            var apartments = await _apartmentService.GetAllApartmentsNonDeletedAsync();
            return Json(new { data = apartments });
        }

        [HttpGet]
        public async Task<IActionResult> GetBlocksBySiteId(Guid siteId)
        {
            var blocks = await _blockService.GetAllBlocksBySiteIdAsync(siteId);
            return Json(blocks);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ApartmentAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var errorMessage = await _apartmentService.AddApartmentAsync(dto);

                if (errorMessage != null)
                {
                    return Json(new { success = false, message = errorMessage });
                }

                return Json(new { success = true, message = "Daire başarıyla eklendi." });
            }

            // EĞER BURAYA DÜŞÜYORSA: Model eşleşmesinde bir sorun var demektir.
            // Hataları toplayıp ekrana gönderelim:
            var errors = string.Join("<br/>", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));

            return Json(new { success = false, message = $"<b>Validasyon Hatası:</b><br/>{errors}" });
        }

        [HttpGet]
        public async Task<IActionResult> GetApartment(Guid id)
        {
            var apartment = await _apartmentService.GetApartmentByIdAsync(id);
            return Json(apartment);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ApartmentUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                var errorMessage = await _apartmentService.UpdateApartmentAsync(dto);

                if (errorMessage != null)
                {
                    return Json(new { success = false, message = errorMessage });
                }

                return Json(new { success = true, message = "Daire başarıyla güncellendi." });
            }
            return Json(new { success = false, message = "Lütfen form bilgilerini eksiksiz doldurun." });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _apartmentService.SafeDeleteApartmentAsync(id);
            return Json(new { success = true, message = "Daire silindi." });
        }
    }
}