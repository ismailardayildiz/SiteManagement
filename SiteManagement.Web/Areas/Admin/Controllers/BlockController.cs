using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Blocks;
using SiteManagement.Entity.DTOs.Sites;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlockController : Controller
    {
        private readonly IBlockService blockService;
        private readonly ISiteService siteService;

        public BlockController(IBlockService blockService, ISiteService siteService)
        {
            this.blockService = blockService;
            this.siteService = siteService;
        }

        public async Task<IActionResult> Index()
        {
            var blocks = await blockService.GetAllBlocksWithSitesAsync();
            return View(blocks);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var sites = await siteService.GetAllSitesWithManagerNameAsync();
            return PartialView("Add", new BlockAddDto { Sites = sites });
        }

        [HttpPost]
        public async Task<IActionResult> Add(BlockAddDto blockAddDto)
        {
            if (ModelState.IsValid)
            {
                await blockService.CreateBlockAsync(blockAddDto);
                return Json(new { success = true });
            }
            blockAddDto.Sites = await siteService.GetAllSitesWithManagerNameAsync();
            return PartialView("Add", blockAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var block = await blockService.GetBlockUpdateDtoAsync(id);
            block.Sites = await siteService.GetAllSitesWithManagerNameAsync();
            return PartialView("Update", block);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlockUpdateDto blockUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await blockService.UpdateBlockAsync(blockUpdateDto);
                return Json(new { success = true });
            }
            blockUpdateDto.Sites = await siteService.GetAllSitesWithManagerNameAsync();
            return PartialView("Update", blockUpdateDto);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await blockService.SafeDeleteBlockAsync(id);
            return Json(new { success = true, message = "Blok başarıyla silindi." });
        }
    }
}
