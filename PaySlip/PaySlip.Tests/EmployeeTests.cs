using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void GivenThatAnnualSalaryIsSixtyThousand_WhenMonthlySalaryIsCalculated_ThenMonthlySalaryIsFiveThousand()
        {
            var paymentDetails = new PaymentDetails(60000, It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>());
            var employee = new Employee(It.IsAny<string>(), It.IsAny<string>(), paymentDetails);
            const int expectedMonthlySalary = 5000;
            var actualMonthlySalary = employee.GetMonthlySalary();
            
            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }
        
        [Fact]
        public void GivenThatAnnualSalaryIsSeventyThousand_WhenMonthlySalaryIsCalculated_ThenMonthlySalaryIsFiveThousandEightHundredAndThirtyThree()
        {
            var paymentDetails = new PaymentDetails(70000, It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>());
            var employee = new Employee(It.IsAny<string>(), It.IsAny<string>(), paymentDetails);
            const int expectedMonthlySalary = 5833;
            var actualMonthlySalary = employee.GetMonthlySalary();
            
            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }
        
        [Fact]
        public void GivenThatMonthlySalaryIsFiveThousandAndSuperRateIsNinePercent_WhenMonthlySuperAnnuationIsCalculated_ThenMonthlySuperAnnuationIsFourHundredAndFifty()
        {
            var paymentDetails = new PaymentDetails(60000, 9, It.IsAny<string>(), It.IsAny<string>());
            var employee = new Employee(It.IsAny<string>(), It.IsAny<string>(), paymentDetails);
            const int expectedMonthlySuperAnnuation = 450;
            var actualMonthlyAnnuation = employee.GetMonthlySuperAnnuation();
            
            Assert.Equal(expectedMonthlySuperAnnuation, actualMonthlyAnnuation);
        }
    }
}