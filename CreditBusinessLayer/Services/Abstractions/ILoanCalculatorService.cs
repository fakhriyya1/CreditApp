using CreditEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditBusinessLayer.Services.Abstractions
{
    public interface ILoanCalculatorService
    {
        Task<LoanCalculationResult> CalculateLoan(int id);
    }
}
