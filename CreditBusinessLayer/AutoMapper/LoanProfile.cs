using AutoMapper;
using CreditEntityLayer.DTOs.Loan;
using CreditEntityLayer.Entities;

namespace CreditBusinessLayer.AutoMapper
{
	public class LoanProfile:Profile
    {
        public LoanProfile()
        {
            CreateMap<LoanDetail, LoanDetailDto>();
            CreateMap<LoanDetailAddDto, LoanDetail>();
        }
    }
}
