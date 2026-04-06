using AutoMapper;
using SiteManagement.Data.Mappings;
using SiteManagement.Entity.DTOs.Managers;
using SiteManagement.Entity.DTOs.Sites;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.AutoMapper.Sites
{
    public class SiteProfile : Profile
    {
        public SiteProfile()
        {
            CreateMap<SiteDto, Site>().ReverseMap()
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => $"{src.Manager.FirstName} {src.Manager.LastName}"));

            CreateMap<SiteAddDto, Site>().ReverseMap();

            CreateMap<SiteUpdateDto, Site>().ReverseMap();

            CreateMap<ManagerAddDto, AppUser>().ReverseMap();

        }
    }
}
