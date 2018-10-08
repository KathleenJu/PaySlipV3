using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void GivenThatAnnualSalaryIsSixtyThousand_WhenMonthlySalaryIsCalculated_ThenMonthlySalaryIsFiveThousand()
        {
            var paymentDetails = new PaymentDetails(60000, 9, It.IsAny<string>(), It.IsAny<string>());
            var employee = new Employee(It.IsAny<string>(), paymentDetails);
            var expectedMonthlySalary = 5000;
            var actualMonthlySalary = employee.GetMonthlySalary();
            
            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }
    }
}