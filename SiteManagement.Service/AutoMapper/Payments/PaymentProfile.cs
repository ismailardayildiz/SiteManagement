using AutoMapper;
using SiteManagement.Entity.DTOs.Payments;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.AutoMapper.Payments
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentAddDto>().ReverseMap();
        }
    }
}
