using Microsoft.AspNetCore.Mvc;
using SiteManagement.Entity.DTOs.Dues;
using SiteManagement.Entity.DTOs.Payments;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;
using SiteManagement.Service.Services.Concretes;
using System;
using System.Threading.Tasks;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DueController : Controller
    {
        private readonly IDueService _dueService;
        private readonly IApartmentService _apartmentService;
        private readonly ISiteService siteService;
        private readonly IPaymentService paymentService;

        public DueController(IDueService dueService, IApartmentService apartmentService, ISiteService siteService, IPaymentService paymentService)
        {
            _dueService = dueService;
            _apartmentService = apartmentService;
            this.siteService = siteService;
            this.paymentService = paymentService;
        }

        // Aidat Listeleme Sayfası
        public async Task<IActionResult> Index()
        {
            var dues = await _dueService.GetAllDuesNonDeletedAsync();

            // Sadece Siteleri gönderiyoruz, daireler seçim yapılınca gelecek
            ViewBag.Sites = await siteService.GetAllSitesNonDeletedAsync();

            return View(dues);
        }

        // Site seçildiğinde daireleri getirecek basit metot
        [HttpGet]
        public async Task<JsonResult> GetApartmentsBySite(Guid siteId)
        {
            var apartments = await _apartmentService.GetAllApartmentsNonDeletedAsync();

            var filteredApartments = apartments
                .Where(x => x.SiteId == siteId)
                .Select(x => new {
                    id = x.Id,
                    name = $"{x.BlockName} - No: {x.ApartmentNumber}" // Daire adı
                }).ToList();

            return Json(filteredApartments);
        }

        // Aidat Ekleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // Daireleri dropdown'da göstermek için çekiyoruz
            var apartments = await _apartmentService.GetAllApartmentsNonDeletedAsync();
            ViewBag.Apartments = apartments;

            return View();
        }

        // Aidat Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> Add(DueAddDto dueAddDto)
        {
            var result = await _dueService.AddDueAsync(dueAddDto);

            // Eğer AddDueAsync'den bir hata mesajı dönerse (örn: "Bu aya ait aidat zaten var")
            if (result != null)
            {
                ModelState.AddModelError("", result);

                // Sayfayı tekrar gösterirken Daire listesini tekrar doldurmalıyız
                var apartments = await _apartmentService.GetAllApartmentsNonDeletedAsync();
                ViewBag.Apartments = apartments;

                return View(dueAddDto);
            }

            // İşlem başarılıysa listeye geri dön
            return RedirectToAction("Index", "Due", new { Area = "Admin" });
        }

        // Aidat Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> Update(Guid dueId)
        {
            var due = await _dueService.GetDueByIdAsync(dueId);
            var apartments = await _apartmentService.GetAllApartmentsNonDeletedAsync();

            ViewBag.Apartments = apartments;
            return View(due);
        }

        // Aidat Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> Update(DueUpdateDto dueUpdateDto)
        {
            var result = await _dueService.UpdateDueAsync(dueUpdateDto);

            if (result != null)
            {
                ModelState.AddModelError("", result);
                var apartments = await _apartmentService.GetAllApartmentsNonDeletedAsync();
                ViewBag.Apartments = apartments;
                return View(dueUpdateDto);
            }

            return RedirectToAction("Index", "Due", new { Area = "Admin" });
        }
        [HttpGet]
        public async Task<JsonResult> GetDueForUpdate(Guid dueId)
        {
            var due = await _dueService.GetDueByIdAsync(dueId);
            // Modalda siteyi de seçili getirmek için dairenin site bilgisini alıyoruz
            var apartment = await _apartmentService.GetApartmentByIdAsync(due.ApartmentId);

            return Json(new
            {
                due = due,
                siteId = apartment.SiteId
            });
        }

        // Constructor'da IDueService ve IPaymentService inject edilmiş olmalı

        [HttpGet]
        public async Task<IActionResult> Collect(Guid dueId)
        {
            // Veritabanı sorgusunu servise devrettik
            var due = await _dueService.GetDueWithDetailsAsync(dueId);

            var model = new PaymentAddDto
            {
                DueId = due.Id,
                TotalDueAmount = due.Amount,
                ApartmentInfo = $"{due.Apartment.Block.Name} - Daire: {due.Apartment.ApartmentNumber}",
                PayerId = due.Apartment.TenantId ?? due.Apartment.OwnerId ?? Guid.Empty // Varsa kiracı, yoksa ev sahibi
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Collect(PaymentAddDto paymentAddDto)
        {
            await paymentService.AddPaymentAsync(paymentAddDto);
            return RedirectToAction("Index", "Due", new { Area = "Admin" });
        }


        public async Task<JsonResult> GetDueForCollect(Guid dueId)
        {
            try
            {
                var due = await _dueService.GetDueWithDetailsAsync(dueId);

                return Json(new
                {
                    dueId = due.Id,
                    totalDueAmount = due.Amount,
                    apartmentInfo = $"{due.Apartment.Block.Name} - Daire: {due.Apartment.ApartmentNumber}",
                    payerId = due.Apartment.TenantId ?? due.Apartment.OwnerId ?? Guid.Empty,
                    paymentDate = DateTime.Now.ToString("yyyy-MM-dd")
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        // Silme İşlemi (Safe Delete)
        public async Task<IActionResult> Delete(Guid dueId)
        {
            await _dueService.SafeDeleteDueAsync(dueId);
            return RedirectToAction("Index", "Due", new { Area = "Admin" });
        }
    }
}
