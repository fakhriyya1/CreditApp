using CreditBusinessLayer.Services.Abstractions;
using CreditDataLayer.UnitOfWorks;
using CreditEntityLayer.Entities;
using System;
using System.Collections.Generic;

namespace CreditBusinessLayer.Services.Concretes
{
    
    public class LoanCalculatorService : ILoanCalculatorService
    {
        private readonly IUnitOfWork unitOfWork;

        public LoanCalculatorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<LoanCalculationResult> CalculateLoan(int id)
        {
            var loanDetails = await unitOfWork.GetRepository<LoanDetail>().GetByIdAsync(id);

            var result = new LoanCalculationResult
            {
                Schedule = new List<AmortizationScheduleEntry>()
            };

            result.Currency=loanDetails.Currency;

            double monthlyRate = (double)(loanDetails.InterestRate / 100 / 12);
            int numberOfPayments = loanDetails.TermInMonths;
            double principal = (double)loanDetails.Principal;

            double monthlyPayment = principal * monthlyRate / (1 - Math.Pow(1 + monthlyRate, -numberOfPayments));

            result.MonthlyPayment = (decimal)monthlyPayment;

            double balance = principal;

            for (int month = 1; month <= numberOfPayments; month++)
            {
                double interest = balance * monthlyRate;
                double principalPayment = monthlyPayment - interest;
                balance -= principalPayment;

                result.Schedule.Add(new AmortizationScheduleEntry
                {
                    Month = month,
                    Payment = (decimal)monthlyPayment,
                    Principal = (decimal)principalPayment,
                    Interest = (decimal)interest,
                    Balance = (decimal)balance
                });
            }

            return result;
        }
    }
}
