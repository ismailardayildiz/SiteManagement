// SiteManagement.Service/AutoMapper/Users/UserProfile.cs
using AutoMapper;
using SiteManagement.Entity.DTOs.Users;
using SiteManagement.Entity.Entities;

namespace SiteManagement.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<AppUser, UserAddDto>().ReverseMap();
            CreateMap<AppUser, UserUpdateDto>().ReverseMap();
        }
    }
}