using CreditEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.DTOs.Loan
{
    public record LoanDetailDto
    {
        public int Id { get; init; }
        public string PurposeOfLoan { get; init; }
        public decimal Principal { get; init; }
        public int TermInMonths { get; init; }
        public float InterestRate { get; init; }
        public Currency Currency { get; init; }
        public LoanStatus LoanStatus { get; init; }
        public string? ReasonForDeclining { get; init; }

    }
}
