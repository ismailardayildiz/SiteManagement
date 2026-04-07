using AutoMapper;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Blocks;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Concretes
{
    public class BlockService : IBlockService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BlockService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<BlockDto>> GetAllBlocksWithSitesAsync()
        {
            // Blokları bağlı oldukları Site bilgisiyle birlikte getirir
            var blocks = await unitOfWork.GetRepository<Block>().GetAllAsync(x => !x.IsDeleted, b => b.Site);
            return mapper.Map<List<BlockDto>>(blocks);
        }

        public async Task CreateBlockAsync(BlockAddDto blockAddDto)
        {
            var block = new Block
            {
                Name = blockAddDto.Name,
                FloorCount = blockAddDto.FloorCount, // Kat sayısı ataması
                SiteId = blockAddDto.SiteId
            };
            await unitOfWork.GetRepository<Block>().AddAsync(block);
            await unitOfWork.SaveAsync();
        }

        public async Task<BlockUpdateDto> GetBlockUpdateDtoAsync(Guid blockId)
        {
            var block = await unitOfWork.GetRepository<Block>().GetAsync(x => x.Id == blockId, x => x.Site);
            return mapper.Map<BlockUpdateDto>(block);
        }

        public async Task UpdateBlockAsync(BlockUpdateDto blockUpdateDto)
        {
            var block = await unitOfWork.GetRepository<Block>().GetByGuidAsync(blockUpdateDto.Id);

            block.Name = blockUpdateDto.Name;
            block.FloorCount = blockUpdateDto.FloorCount;
            block.SiteId = blockUpdateDto.SiteId;

            await unitOfWork.GetRepository<Block>().UpdateAsync(block);
            await unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteBlockAsync(Guid blockId)
        {
            var block = await unitOfWork.GetRepository<Block>().GetByGuidAsync(blockId);
            block.IsDeleted = true;
            block.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Block>().UpdateAsync(block);
            await unitOfWork.SaveAsync();
        }
    }
}
