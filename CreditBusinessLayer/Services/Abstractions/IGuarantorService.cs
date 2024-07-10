using CreditEntityLayer.DTOs.Customer;
using CreditEntityLayer.DTOs.Guarantor;
using CreditEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditBusinessLayer.Services.Abstractions
{
    public interface IGuarantorService
    {
        Task<IEnumerable<GuarantorDto>> GetAllGuarantors();
        Task<GuarantorDetailsDto?> GetGuarantorByIdAsync(int? id);
        Task<IEnumerable<Guarantor>> GetGuarantorsByLoanIdAsync(int loanId);
        Task<string> AddGuarantorAsync(GuarantorAddDto guarantorAddDto);
        Task<Guarantor?> Exists(GuarantorAddDto guarantorAdd);

    }
}
