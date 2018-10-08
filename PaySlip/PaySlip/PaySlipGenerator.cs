using System;
using System.Globalization;

namespace PaySlip
{
    public class PaySlipGenerator
    {
        private readonly Employee _employee;
        private readonly ITaxation _taxation;

        public PaySlipGenerator(Employee employee, ITaxation taxation)
        {
            _employee = employee;
            _taxation = taxation;
        }

        public string GetFullName()
        {
            return ToCapitalise(_employee.FirstName + " " + _employee.LastName);
        }

        private string ToCapitalise(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
        }

        public string GetPaymentPeriod()
        {
            return _employee.GetPaymentPeriod();
        }

        public int GetGrossIncome()
        {
            var monthlySalary = _employee.GetAnnualSalary() / 12;
            return (int) Math.Round((double) monthlySalary);
        }

        public int GetSuperAnnuation()
        {
            var superRateDecimal = (double) _employee.GetSuperRate() / 100;
            var superAnnuation = GetGrossIncome() * superRateDecimal;
            return (int) superAnnuation;
        }

        public int GetIncomeTax()
        {
            return _taxation.GetTax(_employee.GetAnnualSalary());
        }
    }
}