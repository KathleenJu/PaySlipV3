using System;

namespace PaySlip.Tests
{
    public class TaxCalculator
    {
        public int GetGrossIncome(int annualSalary)
        {
            const int monthsInAYear = 12;
            var grossIncome = Math.Round((double) (annualSalary / monthsInAYear));
            return (int) grossIncome;
        }
        
        public int GetSuper(int grossIncome, int superRatePercentage)
        {
            var superRateInDecimal = (double) superRatePercentage/ 100;
            var super = grossIncome * superRateInDecimal;
            return (int) super;
        }

        public int GetNetIncome(int grossIncome, int incomeTax)
        {
            var netIncome = grossIncome - incomeTax;
            return netIncome;
        }

        public int GetIncomeTax(int annualSalary)
        {
            throw new NotImplementedException();
        }
    }
}