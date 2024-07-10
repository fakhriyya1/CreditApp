using CreditEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditBusinessLayer.Services.Abstractions
{
    public interface IPdfService
    {
        MemoryStream GenerateLoanPdf(LoanCalculationResult loanResult);
    }
}
