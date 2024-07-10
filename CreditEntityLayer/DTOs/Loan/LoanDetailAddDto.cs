using CreditEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.DTOs.Loan
{
    public record LoanDetailAddDto
    {
        [Required(ErrorMessage ="Purpose of Loan is a required field.")]
        public string PurposeOfLoan { get; init; }

        [Required(ErrorMessage = "Principal is a required field.")]
        public decimal Principal { get; init; }

        [Required(ErrorMessage = "Loan Term is a required field.")]
        public int TermInMonths { get; init; }

        [Required(ErrorMessage = "Interest Rate is a required field.")]
        public float InterestRate { get; init; }
        [Required]
        public Currency Currency { get; init; }

        public int CustomerId { get; init; }
    }
}
