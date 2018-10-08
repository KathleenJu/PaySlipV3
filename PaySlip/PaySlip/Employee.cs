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

        public int GetAnnualSalary()
        {
            return PaymentDetails.AnnualSalary;
        }

        public int GetSuperRate()
        {
            return PaymentDetails.SuperRate;
        }

        public string GetPaymentPeriod()
        {
            return PaymentDetails.PaymentPeriod;
        }
    }
}