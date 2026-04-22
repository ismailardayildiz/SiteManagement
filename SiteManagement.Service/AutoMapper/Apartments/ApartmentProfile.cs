using AutoMapper;
using SiteManagement.Entity.DTOs.Apartments;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.AutoMapper.Apartments
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Apartment, ApartmentListDto>()
                .ForMember(dest => dest.SiteName, opt => opt.MapFrom(src => src.Site.Name))
                .ForMember(dest => dest.BlockName, opt => opt.MapFrom(src => src.Block.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    src.TenantId != null || src.IsRented ? "Kiracı" :
                    (src.OwnerId != null ? "Ev Sahibi" : "Boş")))
                .ForMember(dest => dest.TenantName, opt => opt.MapFrom(src => src.Tenant != null ? src.Tenant.FirstName + " " + src.Tenant.LastName : null))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner != null ? src.Owner.FirstName + " " + src.Owner.LastName : null));


            CreateMap<ApartmentAddDto, Apartment>();
            CreateMap<Apartment, ApartmentUpdateDto>().ReverseMap();
        }
    }
}
