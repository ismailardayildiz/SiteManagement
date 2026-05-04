using SiteManagement.Entity.DTOs.Complaints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IComplaintService
    {
        Task<List<ComplaintDto>> GetAllComplaintsAsync();
        Task<ComplaintDto> GetComplaintByIdAsync(Guid id);
        Task<string> UpdateComplaintAsync(ComplaintUpdateDto complaintUpdateDto);
        // Diğer metotların yanına ekle:
        Task<string> CreateComplaintAsync(ComplaintAddDto complaintAddDto);
    }
}
