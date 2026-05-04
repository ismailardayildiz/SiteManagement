using AutoMapper;
using SiteManagement.Entity.DTOs.Employees;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.AutoMapper.Employees
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeAddDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

            CreateMap<Employee, EmployeeListDto>()
                .ForMember(dest => dest.SiteName, opt => opt.MapFrom(src => src.Site.Name))
                .ReverseMap();
        }
    }
}
