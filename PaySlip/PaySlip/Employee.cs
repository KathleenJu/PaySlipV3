using System;

namespace PaySlip.Tests
{
    public class Employee
    {
        private readonly string _name;
        private readonly PaymentDetails _paymentDetails;

        public Employee(string name, PaymentDetails paymentDetails)
        {
            _name = name;
            _paymentDetails = paymentDetails;
        }

        public int GetMonthlySalary()
        {
            return (int) Math.Round((double) (_paymentDetails._annualSalary / 12));
        }
    }
}