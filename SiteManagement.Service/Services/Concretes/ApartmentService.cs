using AutoMapper;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Apartments;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Concretes
{
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ApartmentListDto>> GetAllApartmentsNonDeletedAsync()
        {
            var apartments = await _unitOfWork.GetRepository<Apartment>().GetAllAsync(a => !a.IsDeleted, a => a.Site, a => a.Block, a => a.Tenant, a => a.Owner );
            return _mapper.Map<List<ApartmentListDto>>(apartments);
        }

        public async Task<ApartmentUpdateDto> GetApartmentByIdAsync(Guid id)
        {
            var apartment = await _unitOfWork.GetRepository<Apartment>().GetAsync(a => a.Id == id && !a.IsDeleted);
            return _mapper.Map<ApartmentUpdateDto>(apartment);
        }

        public async Task<string> AddApartmentAsync(ApartmentAddDto apartmentAddDto)
        {
            // Aynı blokta, aynı katta, aynı daire numarasına sahip silinmemiş bir kayıt var mı kontrolü
            var hasApartment = await _unitOfWork.GetRepository<Apartment>()
                .GetAsync(a => a.BlockId == apartmentAddDto.BlockId &&
                               a.Floor == apartmentAddDto.Floor &&
                               a.ApartmentNumber == apartmentAddDto.ApartmentNumber &&
                               !a.IsDeleted);

            if (hasApartment != null)
            {
                return "Bu blokta, belirtilen kat ve daire numarasına sahip başka bir daire zaten kayıtlı!";
            }

            var apartment = _mapper.Map<Apartment>(apartmentAddDto);
            await _unitOfWork.GetRepository<Apartment>().AddAsync(apartment);
            await _unitOfWork.SaveAsync();

            return null; 
        }

        public async Task<string> UpdateApartmentAsync(ApartmentUpdateDto apartmentUpdateDto)
        {
            var hasApartment = await _unitOfWork.GetRepository<Apartment>()
                .GetAsync(a => a.BlockId == apartmentUpdateDto.BlockId &&
                               a.Floor == apartmentUpdateDto.Floor &&
                               a.ApartmentNumber == apartmentUpdateDto.ApartmentNumber &&
                               a.Id != apartmentUpdateDto.Id && 
                               !a.IsDeleted);

            if (hasApartment != null)
            {
                return "Bu blokta, belirtilen kat ve daire numarasına sahip başka bir daire zaten kayıtlı!";
            }

            var apartment = await _unitOfWork.GetRepository<Apartment>().GetAsync(a => a.Id == apartmentUpdateDto.Id && !a.IsDeleted);
            _mapper.Map(apartmentUpdateDto, apartment);
            apartment.ModifiedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Apartment>().UpdateAsync(apartment);
            await _unitOfWork.SaveAsync();

            return null; // Hata yok, işlem başarılı
        }

        public async Task SafeDeleteApartmentAsync(Guid id)
        {
            var apartment = await _unitOfWork.GetRepository<Apartment>().GetAsync(a => a.Id == id);
            apartment.IsDeleted = true;
            apartment.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Apartment>().UpdateAsync(apartment);
            await _unitOfWork.SaveAsync();
        }
    }
}
