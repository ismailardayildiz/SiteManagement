using Microsoft.AspNetCore.Identity;
using SiteManagement.Entity.DTOs.Sites;
using SiteManagement.Entity.DTOs.Users;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface ISiteService
    {
        Task<List<SiteDto>> GetAllSitesNonDeletedAsync();
        Task<List<SiteDto>> GetAllSitesWithManagerNameAsync();
        Task<IdentityResult> CreateSiteWithManagerAsync(SiteAddDto siteAddDto);
        Task<IdentityResult> UpdateSiteWithManagerAsync(SiteUpdateDto siteUpdateDto);
        Task SafeDeleteSiteAsync(Guid siteId);
    }
}
