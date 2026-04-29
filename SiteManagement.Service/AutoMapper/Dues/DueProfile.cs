using AutoMapper;
using SiteManagement.Entity.DTOs.Dues;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.AutoMapper.Dues
{
    public class DueProfile : Profile
    {
        public DueProfile()
        {
            CreateMap<Due, DueListDto>().ReverseMap();
            CreateMap<Due, DueAddDto>().ReverseMap();
            CreateMap<Due, DueUpdateDto>().ReverseMap();
        }
    }
}
