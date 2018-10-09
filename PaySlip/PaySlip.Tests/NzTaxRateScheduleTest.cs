using System.Collections.Generic;
using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class NzTaxRateScheduleTest
    {
        [Fact]
        public void GivenThatAnnualSalaryIsSixtyThousand_WhenIncomeTaxIsCalculated_ThenIncomeTaxIsNineHundredAndTwentyOne()
        {
            var taxBrackets = new List<TaxBracket>{new TaxBracket(37001, 87000, 37000, 0.325, 3572)};
            var nzTaxRateSchedule = new NzTaxRateSchedule(taxBrackets);
            const int annualSalary = 60000;

            const int expectedIncomeTax = 921;
            var actualIncomeTax = nzTaxRateSchedule.GetTax(annualSalary);
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
        
        [Fact]
        public void GivenThatAnnualSalaryIsNinetyThousand_WhenIncomeTaxIsCalculated_ThenIncomeTaxIsOneThousandFortyFour()
        {
            var taxRateSchedules = new List<TaxBracket>{new TaxBracket(87001, 180000, 87000, 0.37, 19822)};
            var nzTaxRateSchedule = new NzTaxRateSchedule(taxRateSchedules);
            const int annualSalary = 90000;
                
            const int expectedIncomeTax = 1744;
            var actualIncomeTax = nzTaxRateSchedule.GetTax(annualSalary);
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }
}