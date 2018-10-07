using System;
using Xunit;

namespace PaySlip.Tests
{
    public class TaxCalculatorShould
    {
        private readonly TaxCalculator _taxCalculator = new TaxCalculator();
        [Fact]
        public void GivenAnnualSalaryIsSixtyThousand_WhenGrossIncomeIsCalculated_ThenGrossIncomeShouldBeFiveThousand()
        {
            const int annualSalary = 60000;
            const int expectedGrossIncome = 5000;
            var actualGrossIncome = _taxCalculator.GetGrossIncome(annualSalary);
            
            Assert.Equal(expectedGrossIncome, actualGrossIncome);
        }
        
        [Fact]
        public void GivenGrosssIncomeIsFiveThousandAndSuperRateIsNinePercent_WhenSuperIsCalculated_ThenSuperShouldBeFourHundredFifty()
        {
            const int grossIncome = 5000;
            const int superRate = 9;
            const int expectedSuper = 450;
            var actualSuper = _taxCalculator.GetSuper(grossIncome, superRate);
            
            Assert.Equal( expectedSuper, actualSuper);
        }
        
        [Fact]
        public void GivenGrosssIncomeIsFiveThousandAndIncomeTaxIsNineHundred_WhenNetIncomeIsCalculated_ThenNetIncomeShouldBeFourThousandAndOneHundred()
        {
            const int grossIncome = 5000;
            const int incomeTax = 900;
            const int expectedNetIncome = 4100;
            var actualNetIncome = _taxCalculator.GetNetIncome(grossIncome, incomeTax);
            
            Assert.Equal( expectedNetIncome, actualNetIncome);
        }
        
        [Fact]
        public void GivenAnnualSalaryIsSixtyThousand_WhenIncomeTaxIsCalculated_ThenIncomeTaxShouldBeNineHundredAndTwentyOne()
        {
            const int annualSalary = 5000;
            const int expectedIncomeTax  = 4100;
            var actualIncomeTax = _taxCalculator.GetIncomeTax(annualSalary);
            
            Assert.Equal( expectedIncomeTax, actualIncomeTax);
        }
    }
}