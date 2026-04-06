using SiteManagement.Entity.DTOs.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementDto>> GetAllAnnouncementsWithSiteAsync();
        Task CreateAnnouncementAsync(AnnouncementAddDto announcementAddDto);
        Task UpdateAnnouncementAsync(AnnouncementUpdateDto announcementUpdateDto);
        Task SafeDeleteAnnouncementAsync(Guid id);
    }
}
