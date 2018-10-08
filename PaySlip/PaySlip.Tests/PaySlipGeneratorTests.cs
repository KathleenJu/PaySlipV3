using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class PaySlipTests
    {
        [Fact]
        public void GetFullNameOfEmployee()
        {
            var emp = new Employee("John", "Doe", It.IsAny<PaymentDetails>());
            var paySlipGenerator = new PaySlipGenerator(emp, It.IsAny<ITaxation>());
        }
    }
}