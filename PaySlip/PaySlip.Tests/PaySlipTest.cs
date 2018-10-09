using System.Collections.Generic;
using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class PaySlipTest
    {
        [Fact]
        public void GivenThatMonthlySalaryIsFiveThousand_WhenIncomeTaxIsCalculated_ThenIncomeTaxIsNineHundredAndTwentyOne()
        {
            var taxRateSchedules = new List<TaxRateSchedule>{new TaxRateSchedule(37001, 87000, 37000, 0.325, 3572)};
            var nzTaxation = new NzTaxRateSchedule(taxRateSchedules);
            var paySlip = new PaySlip(It.IsAny<string>(), It.IsAny<string>(), 60000, It.IsAny<int>(), It.IsAny<int>(), nzTaxation);
                
            const int expectedIncomeTax = 921;
            var actualIncomeTax = paySlip.GetIncomeTax();
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
        
        [Fact]
        public void GivenThatMonthlySalaryIsNinetyThousand_WhenIncomeTaxIsCalculated_ThenIncomeTaxIsOneThousandFortyFour()
        {
            var taxRateSchedules = new List<TaxRateSchedule>{new TaxRateSchedule(87001, 180000, 87000, 0.37, 19822)};
            var nzTaxation = new NzTaxRateSchedule(taxRateSchedules);
            var paySlip = new PaySlip(It.IsAny<string>(), It.IsAny<string>(), 90000, It.IsAny<int>(), It.IsAny<int>(), nzTaxation);
                
            const int expectedIncomeTax = 1744;
            var actualIncomeTax = paySlip.GetIncomeTax();
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }
}