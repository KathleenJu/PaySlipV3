using System.Globalization;

namespace PaySlip
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        
        private readonly PaymentDetails PaymentDetails;

        public Employee(string firstName, string lastName, PaymentDetails paymentDetails)
        {
            FirstName = firstName;
            LastName = lastName;
            PaymentDetails = paymentDetails;
        }

        public string GetFullName()
        {
            var CultureTextInfo = CultureInfo.CurrentCulture.TextInfo;
            return CultureTextInfo.ToTitleCase(FirstName + " " + LastName);
        }

        public PaySlip GetMonthlyPaySlip(ITaxRateSchedule taxRateSchedule)
        {
            return new PaySlip(GetFullName(), PaymentDetails.GetPaymentPeriod(), PaymentDetails.AnnualSalary, PaymentDetails.GetGrossIncome(), PaymentDetails.GetSuperAnnuation(), taxRateSchedule);
        }
        
    }
}