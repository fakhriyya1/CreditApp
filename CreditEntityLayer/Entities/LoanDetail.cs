using CreditEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.Entities
{
    public class LoanDetail
    {
        public int Id { get; set; }
        public string PurposeOfLoan { get; set; }
        public decimal Principal { get; set; }
        public int TermInMonths { get; set; }
        public float InterestRate { get; set; }
        public string? ReasonForDeclining { get; set; }
        public Currency Currency { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public bool IsConfirmed { get; set; }

        // Relations
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public ICollection<LoanGuarantor> Guarantors { get; set; } = [];
    }
}
