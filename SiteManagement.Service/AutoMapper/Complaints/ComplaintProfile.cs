using AutoMapper;
using SiteManagement.Entity.DTOs.Complaints;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.AutoMapper.Complaints
{
    public class ComplaintProfile : Profile
    {
        public ComplaintProfile()
        {
            CreateMap<Complaint, ComplaintDto>().ReverseMap();
            CreateMap<Complaint, ComplaintUpdateDto>().ReverseMap();
            CreateMap<Complaint, ComplaintAddDto>().ReverseMap();
        }
    }
}
