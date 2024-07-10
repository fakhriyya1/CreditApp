using AutoMapper;
using CreditBusinessLayer.Services.Abstractions;
using CreditDataLayer.UnitOfWorks;
using CreditEntityLayer.DTOs.Customer;
using CreditEntityLayer.DTOs.Guarantor;
using CreditEntityLayer.DTOs.Loan;
using CreditEntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditBusinessLayer.Services.Concretes
{
    public class GuarantorService : IGuarantorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GuarantorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> AddGuarantorAsync(GuarantorAddDto guarantorAddDto)
        {
            var loan = await _unitOfWork.GetRepository<LoanDetail>().GetByIdAsync(guarantorAddDto.LoanId);
            if (loan is null)
                return "null";

            var guarantor = _mapper.Map<Guarantor>(guarantorAddDto);

            await _unitOfWork.GetRepository<Guarantor>().AddAsync(guarantor);
            await _unitOfWork.SaveAsync();

            var loanGuarantor = new LoanGuarantor
            {
                GuarantorId = guarantor.Id,
                LoanDetailId = loan.Id
            };

            await _unitOfWork.GetRepository<LoanGuarantor>().AddAsync(loanGuarantor);

            await _unitOfWork.SaveAsync();

            return "success";
        }

        public async Task<IEnumerable<GuarantorDto>> GetAllGuarantors()
        {
            var guarantors = await _unitOfWork.GetRepository<Guarantor>().GetTableAsQueryable().Include(x=>x.Loans).ThenInclude(y=>y.LoanDetail).ToListAsync();

            var guarantorsDto = _mapper.Map<IEnumerable<GuarantorDto>>(guarantors);

            return guarantorsDto;
        }

        public async Task<GuarantorDetailsDto?> GetGuarantorByIdAsync(int? id)
        {
            var guarantor = await _unitOfWork.GetRepository<Guarantor>().GetByIdAsync((int)id);
            if (guarantor == null)
                return null;

            var guarantorDetailsDto = _mapper.Map<GuarantorDetailsDto>(guarantor);

            return guarantorDetailsDto;
        }

        public async Task<IEnumerable<Guarantor>> GetGuarantorsByLoanIdAsync(int loanId)
        {
            return await _unitOfWork.GetRepository<Guarantor>()
                .GetTableAsQueryable()
                .Where(g => g.Loans.Any(lg => lg.LoanDetailId == loanId))
                .ToListAsync();
        }

        public async Task<Guarantor?> Exists(GuarantorAddDto guarantorAdd)
        {
            var guarantorEntity = await _unitOfWork.GetRepository<Guarantor>().GetTAsync(c => c.PIN == guarantorAdd.PIN);
            if (guarantorEntity == null)
                return null;

            return guarantorEntity;
        }
    }
}
