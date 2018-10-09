using Moq;
using Xunit;

namespace PaySlip.Tests
{
    public class SalaryDetailsTests
    {
        [Fact]
        public void GivenThatAnnualSalaryIsSixtyThousand_WhenGrossIncomeIsCalculated_ThenGrossIncomeIsFiveThousand()
        {
            var salaryDetails = new SalaryDetails(60000, It.IsAny<int>());
            const int expectedMonthlySalary = 5000;
            var actualMonthlySalary = salaryDetails.GetGrossIncome();

            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }

        [Fact]
        public void
            GivenThatAnnualSalaryIsSeventyThousand_WhenMonthlySalaryIsCalculated_ThenMonthlySalaryIsFiveThousandEightHundredAndThirtyThree()
        {
            var salaryDetails = new SalaryDetails(70000, It.IsAny<int>());
            const int expectedMonthlySalary = 5833;
            var actualMonthlySalary = salaryDetails.GetGrossIncome();

            Assert.Equal(expectedMonthlySalary, actualMonthlySalary);
        }

        [Fact]
        public void
            GivenThatMonthlySalaryIsFiveThousandAndSuperRateIsNinePercent_WhenMonthlySuperAnnuationIsCalculated_ThenMonthlySuperAnnuationIsFourHundredAndFifty()
        {
            var salaryDetails = new SalaryDetails(60000, 9);
            const int expectedMonthlySuperAnnuation = 450;
            var actualMonthlyAnnuation = salaryDetails.GetSuperAnnuation();

            Assert.Equal(expectedMonthlySuperAnnuation, actualMonthlyAnnuation);
        }
    }
}