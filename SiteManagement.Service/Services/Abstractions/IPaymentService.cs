using SiteManagement.Entity.DTOs.Dues;
using SiteManagement.Entity.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IPaymentService
    {
        Task AddPaymentAsync(PaymentAddDto paymentAddDto);
    }
}
