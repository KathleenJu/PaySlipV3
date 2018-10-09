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


        public int GetIncomeTax()
        {
            return _taxation.GetTax(_employee.GetAnnualSalary());
        }
    }
}