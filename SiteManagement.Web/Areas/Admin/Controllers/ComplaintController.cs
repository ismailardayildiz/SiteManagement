using Microsoft.AspNetCore.Mvc;
using SiteManagement.Entity.DTOs.Complaints;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComplaintController : Controller
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var complaints = await _complaintService.GetAllComplaintsAsync();
            return View(complaints);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_AddPartial", new ComplaintAddDto());
        }


        [HttpPost]
        public async Task<IActionResult> Add(ComplaintAddDto complaintAddDto)
        {
            if (ModelState.IsValid)
            {
                await _complaintService.CreateComplaintAsync(complaintAddDto);
                return Json(new { isValid = true, message = "Şikayet başarıyla eklendi." });
            }
            return Json(new { isValid = false, message = "Lütfen alanları kontrol ediniz." });
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var complaint = await _complaintService.GetComplaintByIdAsync(id);
            var updateDto = new ComplaintUpdateDto
            {
                Id = complaint.Id,
                Title = complaint.Title,
                Description = complaint.Description,
                Status = complaint.Status
            };
            return PartialView("_UpdatePartial", updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ComplaintUpdateDto complaintUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _complaintService.UpdateComplaintAsync(complaintUpdateDto);
                return Json(new { isValid = true, message = "Şikayet durumu güncellendi." });
            }
            return Json(new { isValid = false, message = "Lütfen alanları kontrol ediniz." });
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var complaint = await _complaintService.GetComplaintByIdAsync(id);
            return PartialView("_DetailPartial", complaint);
        }
    }
}