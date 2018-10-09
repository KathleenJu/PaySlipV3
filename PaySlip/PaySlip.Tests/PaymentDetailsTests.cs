using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class PaymentDetailsTests
    {
        [Fact]
        public void GivenThePaymentDateIsOnMarch_WhenPaymentPeriodIsGenerated_ThenPaymentPeriodIsFirstToThirstyFirstOfMarch()
        {
            var paymentDetails = new PaymentDetails(It.IsAny<int>(), It.IsAny<int>(), "1 March", "31 March");
            const string expectedEmpPaymentPeriod = "01 March - 31 March";
            var actualEmpPaymentPeriod = paymentDetails.GetPaymentPeriod();

            Assert.Equal(expectedEmpPaymentPeriod, actualEmpPaymentPeriod);
        }

        [Fact]
        public void GivenThatAnnualSalaryIsSixtyThousand_WhenGrossIncomeIsCalculated_ThenGrossIncomeIsFiveThousand()
        {
            var paymentDetails = new PaymentDetails(60000, It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>());
            const int expectedMonthlySalary = 5000;
            var actualMonthlySalary = paymentDetails.GetGrossIncome();

            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }

        [Fact]
        public void
            GivenThatAnnualSalaryIsSeventyThousand_WhenMonthlySalaryIsCalculated_ThenMonthlySalaryIsFiveThousandEightHundredAndThirtyThree()
        {
            var paymentDetails = new PaymentDetails(70000, It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>());
            const int expectedMonthlySalary = 5833;
            var actualMonthlySalary = paymentDetails.GetGrossIncome();

            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }

        [Fact]
        public void
            GivenThatMonthlySalaryIsFiveThousandAndSuperRateIsNinePercent_WhenMonthlySuperAnnuationIsCalculated_ThenMonthlySuperAnnuationIsFourHundredAndFifty()
        {
            var paymentDetails = new PaymentDetails(60000, 9, It.IsAny<string>(), It.IsAny<string>());
            const int expectedMonthlySuperAnnuation = 450;
            var actualMonthlyAnnuation = paymentDetails.GetSuperAnnuation();

            Assert.Equal(expectedMonthlySuperAnnuation, actualMonthlyAnnuation);
        }
    }
}