using CreditEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.Entities
{
    public class LoanCalculationResult
    {
        public decimal MonthlyPayment { get; set; }
        public Currency Currency { get; set; }
        public List<AmortizationScheduleEntry> Schedule { get; set; }
    }
}
