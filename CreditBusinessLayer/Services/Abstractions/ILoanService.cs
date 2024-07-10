using CreditEntityLayer.DTOs.Loan;
using CreditEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditBusinessLayer.Services.Abstractions
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanDetailDto>> GetAllLoansAsync();
        Task<IEnumerable<LoanDetailDto?>> GetPendingLoansAsync();
        Task<string> ApproveRequest(int id);
        Task<string> DeclineRequest(int id, string reason);
        Task<LoanDetail?> GetLoanByIdAsync(int id);
        Task<string> AddLoanAsync(LoanDetailAddDto loanDetailAddDto);
    }
}
