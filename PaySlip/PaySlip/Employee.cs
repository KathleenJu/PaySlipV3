using System;

namespace PaySlip.Tests
{
    public class Employee
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly PaymentDetails _paymentDetails;

        public Employee(string firstName, string lastName, PaymentDetails paymentDetails)
        {
            _firstName = firstName;
            _lastName = lastName;
            _paymentDetails = paymentDetails;
        }

        public int GetMonthlySalary()
        {
            var monthlySalary = _paymentDetails._annualSalary / 12;
            return (int) Math.Round((double) monthlySalary);
        }

        public int GetMonthlySuperAnnuation()
        {
            var superAnnuation = GetMonthlySalary() * _paymentDetails._superRate;
            return superAnnuation;
        }
    }
}