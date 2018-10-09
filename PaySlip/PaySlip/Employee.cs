using System.Globalization;
using PaySlip.Tests;

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
            return ToCapitalise(FirstName + " " + LastName);
        }

        private string ToCapitalise(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
        }
        
        public int GetAnnualSalary()
        {
            return PaymentDetails.AnnualSalary;
        }

        public int GetSuperAnnuation()
        {
            return PaymentDetails.GetSuperAnnuation();
        }

        public string GetPaymentPeriod()
        {
            return PaymentDetails.GetPaymentPeriod();
        }
    }
}