using System;
using System.Collections.Generic;
using System.Linq;

namespace PaySlip
{
    public class NzTaxation : Taxation
    {
        private readonly IEnumerable<TaxRateSchedule> TaxRateSchedules;
        
        public NzTaxation(IEnumerable<TaxRateSchedule> taxRateSchedules)
        {
            TaxRateSchedules = taxRateSchedules;
        }
        
        public int GetTax(int annualSalary)
        {
            var taxRateSchedule = TaxRateSchedules.First(x => annualSalary > x.MinimumTaxableIncome && annualSalary < x.MaximumTaxableIncome);
            var yearlyTax = (taxRateSchedule.ExtraTax + (annualSalary - taxRateSchedule.NonTaxableIncome)) * taxRateSchedule.TaxPerDollar;
            return (int) Math.Round((double) (yearlyTax / 12));
        }
    }
}