using System.Collections.Generic;
using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class PaySlipGeneratorTests
    {
        [Fact]
        public void GivenTheFirstNameIsJohnAndLastNameIsDoe_WhenFullNameIsGenerated_ThenFullNameShouldBeJohnDoeInCapital()
        {
            var emp = new Employee("john", "doe", It.IsAny<PaymentDetails>());
            var paySlipGenerator = new PaySlipGenerator(emp, It.IsAny<ITaxation>());
            
            const string expectedEmpFullName = "John Doe";
            var actualEmpFullName = paySlipGenerator.GetFullName();
            
            Assert.Equal(expectedEmpFullName, actualEmpFullName);
        }
        
        [Fact]
        public void GivenThePaymentDateIsOnMarch_WhenPaymentPeriodIsGenerated_ThenPaymentPeriodIsFirstToThirstyFirstOfMarch()
        {
            var paymentDetails = new PaymentDetails(It.IsAny<int>(), It.IsAny<int>(), "1 March", "31 March");
            var emp = new Employee(It.IsAny<string>(), It.IsAny<string>(), paymentDetails);
            var paySlipGenerator = new PaySlipGenerator(emp, It.IsAny<ITaxation>());
            
            const string expectedEmpPaymentPeriod = "01 March - 31 March";
            var actualEmpPaymentPeriod = paySlipGenerator.GetPaymentPeriod();
            
            Assert.Equal(expectedEmpPaymentPeriod, actualEmpPaymentPeriod);
        }
        
        [Fact]
        public void GivenThatAnnualSalaryIsSixtyThousand_WhenGrossIncomeIsCalculated_ThenGrossIncomeIsFiveThousand()
        {
            var paymentDetails = new PaymentDetails(60000, It.IsAny<int>(), "1 March", "31 March");
            var emp = new Employee(It.IsAny<string>(), It.IsAny<string>(), paymentDetails);
            var paySlipGenerator = new PaySlipGenerator(emp, It.IsAny<ITaxation>());
            
            const int expectedMonthlySalary = 5000;
            var actualMonthlySalary = paySlipGenerator.GetGrossIncome();
            
            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }
        
        [Fact]
        public void GivenThatAnnualSalaryIsSeventyThousand_WhenMonthlySalaryIsCalculated_ThenMonthlySalaryIsFiveThousandEightHundredAndThirtyThree()
        {
            var paymentDetails = new PaymentDetails(70000, It.IsAny<int>(), "1 March", "31 March");
            var emp = new Employee(It.IsAny<string>(), It.IsAny<string>(), paymentDetails);
            var paySlipGenerator = new PaySlipGenerator(emp, It.IsAny<ITaxation>());
            
            const int expectedMonthlySalary = 5833;
            var actualMonthlySalary = paySlipGenerator.GetGrossIncome();
            
            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }
        
        [Fact]
        public void GivenThatMonthlySalaryIsFiveThousandAndSuperRateIsNinePercent_WhenMonthlySuperAnnuationIsCalculated_ThenMonthlySuperAnnuationIsFourHundredAndFifty()
        {
            var paymentDetails = new PaymentDetails(60000, 9, "1 March", "31 March");
            var emp = new Employee(It.IsAny<string>(), It.IsAny<string>(), paymentDetails);
            var paySlipGenerator = new PaySlipGenerator(emp, It.IsAny<ITaxation>());
            
            const int expectedMonthlySuperAnnuation = 450;
            var actualMonthlyAnnuation = paySlipGenerator.GetSuperAnnuation();
            
            Assert.Equal(expectedMonthlySuperAnnuation, actualMonthlyAnnuation);
        }
        
        
        [Fact]
        public void GivenThatMonthlySalaryIsFiveThousand_WhenIncomeTaxIsCalculated_ThenIncomeTaxIsNineHundredAndTwentyOne()
        {
            var paymentDetails = new PaymentDetails(60000, It.IsAny<int>(), "1 March", "31 March");
            var emp = new Employee(It.IsAny<string>(), It.IsAny<string>(), paymentDetails);
            var taxRateSchedules = new List<TaxRateSchedule>{new TaxRateSchedule(37001, 87000, 37000, 0.325, 3572)};
            var paySlipGenerator = new PaySlipGenerator(emp, new NzTaxation(taxRateSchedules));
            
            const int expectedIncomeTax = 921;
            var actualIncomeTax = paySlipGenerator.GetIncomeTax();
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }
}