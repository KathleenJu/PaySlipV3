using System;
using System.Collections.Generic;
using System.Linq;

namespace PaySlip
{
    public class NzTaxRateSchedule : ITaxRateSchedule
    {
        private readonly IEnumerable<TaxRateSchedule> TaxBrackets;
        
        public NzTaxRateSchedule(IEnumerable<TaxRateSchedule> taxBrackets)
        {
            TaxBrackets = taxBrackets;
        }
        
        public int GetTax(int annualSalary)
        {
            var taxBracketOfAnnualSalary = GetTaxBracketOfAnnualSalary(annualSalary);
            var yearlyTax = taxBracketOfAnnualSalary.ExtraTax + (annualSalary - taxBracketOfAnnualSalary.NonTaxableIncome) * taxBracketOfAnnualSalary.TaxPerDollar ;
            return (int) Math.Round(yearlyTax / 12);
        }

        private TaxRateSchedule GetTaxBracketOfAnnualSalary(int annualSalary)
        {
            return TaxBrackets.First(tb => annualSalary > tb.MinimumTaxableIncome && annualSalary < tb.MaximumTaxableIncome);
        }
    }
}