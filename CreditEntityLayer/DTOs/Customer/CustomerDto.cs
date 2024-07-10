using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.DTOs.Customer
{
    public record CustomerDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string PIN { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string PhoneNumber1 { get; init; }
    }
}
