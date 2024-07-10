using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.DTOs.Guarantor
{
    public record GuarantorAddDto
    {

        [Required(ErrorMessage = "Full Name is a required field")]
        public string FullName { get; init; }

        [Required(ErrorMessage = "Current Address is a required field")]
        public string CurrentAddress { get; init; }

        [Required(ErrorMessage = "PIN is a required field")]
        public string PIN { get; init; }

        [Required(ErrorMessage = "Card No is a required field")]
        public string CardNo { get; init; }

        [Required(ErrorMessage = "Date of Birth is a required field")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; init; }

        [Required(ErrorMessage = "Phone Number is a required field")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "Please fill out the field correctly")]
        public string PhoneNumber1 { get; init; }
        public string? PhoneNumber2 { get; init; }

        [Required(ErrorMessage = "This is a required field")]
        public string RelationshipToApplicant { get; init; }


        [Required(ErrorMessage = "Position is a required field")]
        public string Position { get; init; }

        [Required(ErrorMessage = "Monthly Income is a required field")]
        public float MonthlyIncome { get; init; }

        public int? ExperienceYears { get; init; }
        public int? ExperienceMonths { get; init; }

        [Required(ErrorMessage = "Region is a required field")]
        public string Region { get; init; }

        [Required(ErrorMessage = "Business Address is a required field")]
        public string BusinessAddress { get; init; }

        public int LoanId { get; init; }
    }
}
