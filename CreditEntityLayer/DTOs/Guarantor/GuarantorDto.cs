using CreditEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.DTOs.Guarantor
{
    public record GuarantorDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string PIN { get; init; }
        public string PhoneNumber1 { get; init; }
        public string RelationshipToApplicant { get; init; }

        public int LoanId { get; init; }
    }
}
