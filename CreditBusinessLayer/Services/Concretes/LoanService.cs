using AutoMapper;
using CreditBusinessLayer.Services.Abstractions;
using CreditDataLayer.UnitOfWorks;
using CreditEntityLayer.DTOs.Loan;
using CreditEntityLayer.Entities;
using CreditEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditBusinessLayer.Services.Concretes
{
    public class LoanService : ILoanService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LoanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDetailDto>> GetAllLoansAsync()
        {
            var loans = await _unitOfWork.GetRepository<LoanDetail>().GetAllAsync();

            var loansDto = _mapper.Map<IEnumerable<LoanDetailDto>>(loans);

            return loansDto;
        }

        public async Task<string> AddLoanAsync(LoanDetailAddDto loanDetailAddDto)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(loanDetailAddDto.CustomerId);
            if (customer is null)
                return "null";

            var loan = _mapper.Map<LoanDetail>(loanDetailAddDto);
            loan.LoanStatus = LoanStatus.Pending;

            await _unitOfWork.GetRepository<LoanDetail>().AddAsync(loan);
            await _unitOfWork.SaveAsync();

            return "success";
        }

        public async Task<LoanDetail?> GetLoanByIdAsync(int id)
        {
            var loan = await _unitOfWork.GetRepository<LoanDetail>().GetByIdAsync(id);
            if(loan is null)
                return null;

            return loan;
        }

        public async Task<IEnumerable<LoanDetailDto?>> GetPendingLoansAsync()
        {
            var pendingLoans = await _unitOfWork.GetRepository<LoanDetail>().GetAllAsync(l=>l.LoanStatus==LoanStatus.Pending);

            var loans=_mapper.Map<IEnumerable<LoanDetailDto>>(pendingLoans);

            return loans;
        }

        public async Task<string> ApproveRequest(int id)
        {
            var loan = await _unitOfWork.GetRepository<LoanDetail>().GetByIdAsync(id);
            if (loan is null)
                return "null";

            loan.IsConfirmed = true;
            loan.LoanStatus=LoanStatus.Approved;

            await _unitOfWork.SaveAsync();

            return "success";
        }

        public async Task<string> DeclineRequest(int id, string reason)
        {
            var loan = await _unitOfWork.GetRepository<LoanDetail>().GetByIdAsync(id);
            if (loan is null)
                return "null";

            loan.LoanStatus = LoanStatus.Rejected;
            loan.ReasonForDeclining= reason;

            await _unitOfWork.SaveAsync();

            return "success";
        }
    }
}
