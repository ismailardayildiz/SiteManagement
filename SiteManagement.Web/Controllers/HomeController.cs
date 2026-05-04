using Microsoft.AspNetCore.Mvc;
using SiteManagement.Entity.Enums;
using SiteManagement.Service.Services.Abstractions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SiteManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IDueService _dueService;

        // Servisleri Dependency Injection (DI) ile alıyoruz
        public HomeController(IAnnouncementService announcementService, IDueService dueService)
        {
            _announcementService = announcementService;
            _dueService = dueService;
        }

        public async Task<IActionResult> Index()
        {
            // Sisteme giriş yapan kullanıcının ID'sini alıyoruz
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Tüm duyuruları çekiyoruz (İsteğe bağlı olarak son 5 duyuru şeklinde sınırlandırılabilir)
            var announcements = await _announcementService.GetAllAnnouncementsWithSiteAsync();

 
            // Not: Servis katmanında GetDuesByUserIdAsync  metodunu kullan.
            var allDues = await _dueService.GetAllDuesNonDeletedAsync();
            var unpaidDues = allDues.Where(x => x.PaymentStatus != PaymentStatus.Paid).ToList(); 

            // Verileri View'a taşıyoruz
            ViewBag.Announcements = announcements;
            ViewBag.UnpaidDues = unpaidDues;

            return View();
        }
    }
}