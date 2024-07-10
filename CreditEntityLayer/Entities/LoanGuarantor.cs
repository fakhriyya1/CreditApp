using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEntityLayer.Entities
{
    public class LoanGuarantor
    {
        public int LoanDetailId { get; set; }
        public LoanDetail LoanDetail { get; set; }

        public int? GuarantorId { get; set; }
        public Guarantor Guarantor { get; set; }
    }
}
