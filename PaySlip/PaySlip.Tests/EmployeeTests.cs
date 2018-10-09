using System.Collections.Generic;
using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void GivenTheFirstNameIsJohnAndLastNameIsDoe_WhenFullNameIsGenerated_ThenFullNameShouldBeJohnDoeInCapital()
        {
            var emp = new Employee("john", "doe", It.IsAny<PaymentDetails>());
            const string expectedEmpFullName = "John Doe";
            var actualEmpFullName = emp.GetFullName();
            
            Assert.Equal(expectedEmpFullName, actualEmpFullName);
        }
    }
}