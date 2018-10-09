using System;
using System.Collections.Generic;
using System.Linq;

namespace PaySlip
{
    public class NzTaxRateSchedule : ITaxRateSchedule
    {
        private readonly IEnumerable<TaxBracket> TaxBrackets;
        
        public NzTaxRateSchedule(IEnumerable<TaxBracket> taxBrackets)
        {
            TaxBrackets = taxBrackets;
        }
        
        public int GetIncomeTax(int annualSalary)
        {
            var taxBracketOfAnnualSalary = GetTaxBracketOfAnnualSalary(annualSalary);
            var yearlyTax = taxBracketOfAnnualSalary.ExtraTax + (annualSalary - taxBracketOfAnnualSalary.NonTaxableIncome) * taxBracketOfAnnualSalary.TaxPerDollar ;
            return (int) Math.Round(yearlyTax / 12);
        }

        private TaxBracket GetTaxBracketOfAnnualSalary(int annualSalary)
        {
            return TaxBrackets.First(tb => annualSalary > tb.MinimumTaxableIncome && annualSalary < tb.MaximumTaxableIncome);
        }
    }
}