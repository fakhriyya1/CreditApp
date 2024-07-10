using CreditEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.Entities
{
    public class AmortizationScheduleEntry
    {
        public int Month { get; set; }
        public decimal Payment { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
    }
}
