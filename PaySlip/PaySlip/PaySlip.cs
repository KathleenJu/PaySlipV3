using System.Collections.Generic;
using System.Linq.Expressions;

namespace PaySlip
{
    public class PaySlip
    {
        public string FullName { get; }
        public string PaymentPeriod { get; }
        public int GrossIncome { get; }
        public int IncomeTax { get; }
        public int NetIncome { get; }
        public int Super { get; }

        private readonly int AnnualSalary;
        public ITaxation _taxation;

        public PaySlip(string name, string paymentPeriod, int annualSalary, int grossIncome, int superAnnuation,
            ITaxation taxation)
        {
            FullName = name;
            PaymentPeriod = paymentPeriod;
            AnnualSalary = annualSalary;
            GrossIncome = grossIncome;
            Super = superAnnuation;
            _taxation = taxation;
            IncomeTax = GetIncomeTax();
            NetIncome = GetNetIncome();
        }

        public int GetIncomeTax()
        {
            var incomeTax = _taxation.GetTax(AnnualSalary);
            return incomeTax;
        }

        private int GetNetIncome()
        {
            return GrossIncome - IncomeTax;
        }
    }
}