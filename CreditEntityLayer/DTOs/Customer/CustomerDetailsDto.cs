using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.DTOs.Customer
{
    public record CustomerDetailsDto
    {
        public string FullName { get; init; }
        public string CurrentAddress { get; init; }
        public string PIN { get; init; }
        public string CardNo { get; init; }
        public string RegistrationAddress { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string PhoneNumber1 { get; init; }
        public string? PhoneNumber2 { get; init; }

        public string Position { get; init; }
        public float MonthlyIncome { get; init; }
        public int? ExperienceYears { get; init; }
        public int? ExperienceMonths { get; init; }
        public string Region { get; init; }
        public string BusinessAddress { get; init; }
    }
}
