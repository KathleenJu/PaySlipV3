using System.Globalization;

namespace PaySlip
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        
        private readonly SalaryDetails _salaryDetails;

        public Employee(string firstName, string lastName, SalaryDetails salaryDetails)
        {
            FirstName = firstName;
            LastName = lastName;
            _salaryDetails = salaryDetails;
        }

        public string GetFullName()
        {
            var CultureTextInfo = CultureInfo.CurrentCulture.TextInfo;
            return CultureTextInfo.ToTitleCase(FirstName + " " + LastName);
        }

        public PaySlip GetMonthlyPaySlip(string paymentStart, string paymentEnd, ITaxRateSchedule taxRateSchedule)
        {
            return new PaySlip(GetFullName(), paymentStart, paymentEnd, _salaryDetails.AnnualSalary, _salaryDetails.GetGrossIncome(), _salaryDetails.GetSuperAnnuation(), taxRateSchedule);
        }
        
    }
}