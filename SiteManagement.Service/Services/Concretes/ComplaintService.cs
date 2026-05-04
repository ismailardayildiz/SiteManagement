using AutoMapper;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Complaints;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Concretes
{
    public class ComplaintService : IComplaintService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComplaintService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ComplaintDto>> GetAllComplaintsAsync()
        {
            // İhtiyaca göre Include işlemi ile User bilgilerini de çekebilirsin
            var complaints = await _unitOfWork.GetRepository<Complaint>().GetAllAsync();
            var map = _mapper.Map<List<ComplaintDto>>(complaints);
            return map;
        }

        public async Task<ComplaintDto> GetComplaintByIdAsync(Guid id)
        {
            var complaint = await _unitOfWork.GetRepository<Complaint>().GetAsync(x => x.Id == id);
            var map = _mapper.Map<ComplaintDto>(complaint);
            return map;
        }

        public async Task<string> UpdateComplaintAsync(ComplaintUpdateDto complaintUpdateDto)
        {
            var complaint = await _unitOfWork.GetRepository<Complaint>().GetAsync(x => x.Id == complaintUpdateDto.Id);

            // Sadece Status alanını güncelliyoruz
            complaint.Status = complaintUpdateDto.Status;

            await _unitOfWork.GetRepository<Complaint>().UpdateAsync(complaint);
            await _unitOfWork.SaveAsync();

            return complaint.Title; // Loglama veya bildirim için başlığı dönebiliriz
        }
        public async Task<string> CreateComplaintAsync(ComplaintAddDto complaintAddDto)
        {
            var complaint = _mapper.Map<Complaint>(complaintAddDto);
            complaint.CreatedDate = DateTime.Now;
            complaint.Status = SiteManagement.Entity.Enums.ComplaintStatus.Pending; // Varsayılan durum: Bekliyor

            await _unitOfWork.GetRepository<Complaint>().AddAsync(complaint);
            await _unitOfWork.SaveAsync();

            return complaint.Title;
        }
    }
}