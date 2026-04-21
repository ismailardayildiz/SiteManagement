using SiteManagement.Entity.DTOs.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IApartmentService
    {
        Task<List<ApartmentListDto>> GetAllApartmentsNonDeletedAsync();
        Task<ApartmentUpdateDto> GetApartmentByIdAsync(Guid id);
        Task<string> AddApartmentAsync(ApartmentAddDto apartmentAddDto);
        Task<string> UpdateApartmentAsync(ApartmentUpdateDto apartmentUpdateDto);
        Task SafeDeleteApartmentAsync(Guid id);
    }
}
