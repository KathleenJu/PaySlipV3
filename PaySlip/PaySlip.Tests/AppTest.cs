using System.Collections.Generic;
using Xunit;

namespace PaySlip.Tests
{
    public class AppTest
    {
        [Fact]
        public void CreateAPaySlipForAnEmployee()
        {
            var employee = new Employee("John", "Doe", new PaymentDetails(60050, 9, "1 March", "31 March"));
            var taxBrackets = new List<TaxBracket>{new TaxBracket(37001, 87000, 37000, 0.325, 3572)};
                
            var nzTaxRateSchedule = new NzTaxRateSchedule(taxBrackets);
            var empPaySlip = employee.GetMonthlyPaySlip(nzTaxRateSchedule);

            Assert.Equal("John Doe", empPaySlip.FullName);
            Assert.Equal("01 March - 31 March", empPaySlip.PaymentPeriod);
            Assert.Equal(5004, empPaySlip.GrossIncome);
            Assert.Equal(922, empPaySlip.IncomeTax);
            Assert.Equal(4082, empPaySlip.NetIncome);
            Assert.Equal(450, empPaySlip.Super);

        }
        
        [Fact]
        public void CreateAPaySlipForAnotherEmployee()
        {
            var employee = new Employee("Joe", "Smith", new PaymentDetails(18000, 3, "1 August", "31 August"));
            var taxBrackets = new List<TaxBracket>{new TaxBracket(0, 18200, 0, 0, 0)};
                
            var nzTaxRateSchedule = new NzTaxRateSchedule(taxBrackets);
            var empPaySlip = employee.GetMonthlyPaySlip(nzTaxRateSchedule);

            Assert.Equal("Joe Smith", empPaySlip.FullName);
            Assert.Equal("01 August - 31 August", empPaySlip.PaymentPeriod);
            Assert.Equal(1500, empPaySlip.GrossIncome);
            Assert.Equal(0, empPaySlip.IncomeTax);
            Assert.Equal(1500, empPaySlip.NetIncome);
            Assert.Equal(45, empPaySlip.Super);

        }
    }
}