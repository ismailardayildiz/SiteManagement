using AutoMapper;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Dues;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Concretes
{
    public class DueService : IDueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DueService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DueListDto>> GetAllDuesNonDeletedAsync()
        {
            // Aidatları çekerken Daire (ve Daire'nin Bloğu) ile Ödemeleri de Include ediyoruz
            var dues = await _unitOfWork.GetRepository<Due>().GetAllAsync(
                d => !d.IsDeleted,
                d => d.Apartment,
                d => d.Apartment.Block,
                d => d.Apartment.Site,
                d => d.Payments);

            return _mapper.Map<List<DueListDto>>(dues);
        }

        public async Task<DueUpdateDto> GetDueByIdAsync(Guid id)
        {
            var due = await _unitOfWork.GetRepository<Due>().GetAsync(d => d.Id == id && !d.IsDeleted);
            return _mapper.Map<DueUpdateDto>(due);
        }

        public async Task<string> AddDueAsync(DueAddDto dueAddDto)
        {
            // İş Kuralı: Aynı daireye, aynı yıl ve ay için zaten bir aidat girilmiş mi?
            var hasDue = await _unitOfWork.GetRepository<Due>()
                .GetAsync(d => d.ApartmentId == dueAddDto.ApartmentId &&
                               d.Year == dueAddDto.Year &&
                               d.Month == dueAddDto.Month &&
                               !d.IsDeleted);

            if (hasDue != null)
            {
                return "Bu daire için belirtilen yıl ve aya ait aidat kaydı zaten mevcut!";
            }

            var due = _mapper.Map<Due>(dueAddDto);
            await _unitOfWork.GetRepository<Due>().AddAsync(due);
            await _unitOfWork.SaveAsync();

            return null; // Başarılı
        }

        public async Task<string> UpdateDueAsync(DueUpdateDto dueUpdateDto)
        {
            // İş Kuralı: Güncellenen yıl/ay bilgisi, o dairenin başka bir aidat kaydıyla çakışıyor mu?
            var hasDue = await _unitOfWork.GetRepository<Due>()
                .GetAsync(d => d.ApartmentId == dueUpdateDto.ApartmentId &&
                               d.Year == dueUpdateDto.Year &&
                               d.Month == dueUpdateDto.Month &&
                               d.Id != dueUpdateDto.Id &&
                               !d.IsDeleted);

            if (hasDue != null)
            {
                return "Bu daire için belirtilen yıl ve aya ait başka bir aidat kaydı zaten mevcut!";
            }

            var due = await _unitOfWork.GetRepository<Due>().GetAsync(d => d.Id == dueUpdateDto.Id && !d.IsDeleted);
            _mapper.Map(dueUpdateDto, due);
            due.ModifiedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Due>().UpdateAsync(due);
            await _unitOfWork.SaveAsync();

            return null; // Başarılı
        }

        public async Task<DueListDto> GetDueWithDetailsAsync(Guid id)
        {
            var due = await _unitOfWork.GetRepository<Due>().GetAsync(
                d => d.Id == id && !d.IsDeleted,
                d => d.Apartment,
                d => d.Apartment.Block);

            return _mapper.Map<DueListDto>(due);
        }

        public async Task SafeDeleteDueAsync(Guid id)
        {
            var due = await _unitOfWork.GetRepository<Due>().GetAsync(d => d.Id == id);
            due.IsDeleted = true;
            due.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Due>().UpdateAsync(due);
            await _unitOfWork.SaveAsync();
        }
    }
}