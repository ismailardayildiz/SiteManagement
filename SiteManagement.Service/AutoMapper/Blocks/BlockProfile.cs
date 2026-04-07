using AutoMapper;
using SiteManagement.Entity.DTOs.Blocks;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.AutoMapper.Blocks
{
    public class BlockProfile : Profile
    {
        public BlockProfile()
        {
            // Listeleme için: Site nesnesinden SiteName'i al
            CreateMap<Block, BlockDto>()
                .ForMember(dest => dest.SiteName, opt => opt.MapFrom(src => src.Site.Name));

            // Ekleme ve Güncelleme için çift yönlü eşleme
            CreateMap<BlockAddDto, Block>();
            CreateMap<BlockUpdateDto, Block>().ReverseMap();
        }
    }
}
