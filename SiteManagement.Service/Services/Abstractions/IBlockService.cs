using SiteManagement.Entity.DTOs.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IBlockService
    {
        Task<List<BlockDto>> GetAllBlocksWithSitesAsync();
        Task CreateBlockAsync(BlockAddDto blockAddDto);
        Task<BlockUpdateDto> GetBlockUpdateDtoAsync(Guid blockId);
        Task UpdateBlockAsync(BlockUpdateDto blockUpdateDto);
        Task SafeDeleteBlockAsync(Guid blockId);
    }
}
