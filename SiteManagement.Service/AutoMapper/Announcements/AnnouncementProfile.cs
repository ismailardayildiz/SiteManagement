using AutoMapper;
using SiteManagement.Entity.DTOs.Announcements;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.AutoMapper.Announcements
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<Announcement, AnnouncementDto>()
                .ForMember(dest => dest.SiteName, opt => opt.MapFrom(src => src.Site.Name));

            CreateMap<AnnouncementAddDto, Announcement>();

            CreateMap<Announcement, AnnouncementUpdateDto>().ReverseMap();
        }
    }
}
