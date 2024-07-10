using AutoMapper;
using CreditEntityLayer.DTOs.Guarantor;
using CreditEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditBusinessLayer.AutoMapper
{
    public class GuarantorProfile : Profile
    {
        public GuarantorProfile()
        {
            CreateMap<GuarantorAddDto, Guarantor>();
            CreateMap<Guarantor, GuarantorDto>()
                .ForMember(dest => dest.LoanId, opt => opt.MapFrom(src => src.Loans.FirstOrDefault().LoanDetailId));
            CreateMap<Guarantor, GuarantorDetailsDto>();
        }
    }
}
