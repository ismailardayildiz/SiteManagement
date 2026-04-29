using SiteManagement.Entity.DTOs.Dues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IDueService
    {
        Task<List<DueListDto>> GetAllDuesNonDeletedAsync();
        Task<DueUpdateDto> GetDueByIdAsync(Guid id);
        Task<string> AddDueAsync(DueAddDto dueAddDto);
        Task<string> UpdateDueAsync(DueUpdateDto dueUpdateDto);
        Task<DueListDto> GetDueWithDetailsAsync(Guid id);
        Task SafeDeleteDueAsync(Guid id);
    }
}
