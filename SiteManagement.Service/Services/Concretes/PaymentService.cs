using AutoMapper;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Dues;
using SiteManagement.Entity.DTOs.Payments;
using SiteManagement.Entity.Entities;
using SiteManagement.Entity.Enums;
using SiteManagement.Service.Services.Abstractions;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Concretes
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddPaymentAsync(PaymentAddDto paymentAddDto)
        {
            var payment = _mapper.Map<Payment>(paymentAddDto);

            // Ödeme durumunu belirleyelim (Varsayılan olarak Completed diyebiliriz)

            await _unitOfWork.GetRepository<Payment>().AddAsync(payment);
            await _unitOfWork.SaveAsync();
        }
    }
}