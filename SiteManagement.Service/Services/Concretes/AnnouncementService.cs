using AutoMapper;
using Microsoft.AspNetCore.Http;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Announcements;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Concretes
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal user;

        public AnnouncementService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<AnnouncementDto>> GetAllAnnouncementsWithSiteAsync()
        {
            var announcements = await unitOfWork.GetRepository<Announcement>().GetAllAsync(x => !x.IsDeleted, a => a.Site);
            return mapper.Map<List<AnnouncementDto>>(announcements);
        }

        public async Task CreateAnnouncementAsync(AnnouncementAddDto announcementAddDto)
        {
            // Giriş yapan kullanıcının ID'sini Claims üzerinden alıyoruz
            var currentUserId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
            // Giriş yapan kullanıcının Adını/Emailini CreatedBy'a yazıyoruz
            var currentUserName = user.FindFirstValue(ClaimTypes.Email);

            var announcement = mapper.Map<Announcement>(announcementAddDto);

            announcement.CreatedById = currentUserId;
            announcement.CreatedBy = currentUserName ?? "Undefined";

            await unitOfWork.GetRepository<Announcement>().AddAsync(announcement);
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateAnnouncementAsync(AnnouncementUpdateDto announcementUpdateDto)
        {
            var announcement = await unitOfWork.GetRepository<Announcement>().GetByGuidAsync(announcementUpdateDto.Id);

            announcement.Title = announcementUpdateDto.Title;
            announcement.Content = announcementUpdateDto.Content;
            announcement.SiteId = announcementUpdateDto.SiteId;

            await unitOfWork.GetRepository<Announcement>().UpdateAsync(announcement);
            await unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteAnnouncementAsync(Guid id)
        {
            var announcement = await unitOfWork.GetRepository<Announcement>().GetByGuidAsync(id);
            announcement.IsDeleted = true;
            announcement.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Announcement>().UpdateAsync(announcement);
            await unitOfWork.SaveAsync();
        }
    }
}
