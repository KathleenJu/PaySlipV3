using System;
using System.Collections.Generic;

namespace PaySlip
{
    public class SalaryDetails
    {
        public int AnnualSalary { get; }
        public int SuperRate { get; }

        public SalaryDetails(int annualSalary, int superRate)
        {
            AnnualSalary = annualSalary;
            SuperRate = superRate;
        }

        public int GetGrossIncome()
        {
            const int monthsInAYear = 12;
            var monthlySalary = AnnualSalary / monthsInAYear;
            return (int) Math.Round((decimal) monthlySalary);
        }

        public int GetSuperAnnuation()
        {
            var superRateDecimal = (double) SuperRate / 100;
            var superAnnuation = GetGrossIncome() * superRateDecimal;
            return (int) Math.Round(superAnnuation);
        }
    }
}