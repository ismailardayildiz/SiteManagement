using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Service.Services.Abstractions;
using SiteManagement.Web.Models;

namespace SiteManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISiteService siteService;

        public HomeController(ILogger<HomeController> logger, ISiteService siteService)
        {
            _logger = logger;
            this.siteService = siteService;
        }

        public async Task<IActionResult> Index()
        {
            var sites = await siteService.GetAllSitesWithManagerNameAsync();
                
            return View(sites);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
