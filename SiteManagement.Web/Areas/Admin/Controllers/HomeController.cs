using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Service.Services.Abstractions;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ISiteService siteService;

        public HomeController(ISiteService siteService)
        {
            this.siteService = siteService;
        }
        public async Task<IActionResult> Index()
        {
            var sites = await siteService.GetAllSitesWithManagerNameAsync();
                return View(sites);
         
        }
    }
}
