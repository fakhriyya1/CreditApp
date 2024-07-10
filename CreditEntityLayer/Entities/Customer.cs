using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CurrentAddress { get; set; }
        public string PIN { get; set; }
        public string CardNo { get; set; }
        public string RegistrationAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }

        public string Position { get; set; }
        public float MonthlyIncome { get; set; }
        public int? ExperienceYears { get; set; }
        public int? ExperienceMonths { get; set; }
        public string Region { get; set; }
        public string BusinessAddress { get; set; }

        //Relations
        public ICollection<LoanDetail> LoanDetails { get; set; } = [];
    }
}
