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
        public ITaxRateSchedule TaxRateSchedule;

        public PaySlip(string name, string paymentPeriod, int annualSalary, int grossIncome, int superAnnuation,
            ITaxRateSchedule taxRateSchedule)
        {
            FullName = name;
            PaymentPeriod = paymentPeriod;
            AnnualSalary = annualSalary;
            GrossIncome = grossIncome;
            Super = superAnnuation;
            TaxRateSchedule = taxRateSchedule;
            IncomeTax = GetIncomeTax();
            NetIncome = GetNetIncome();
        }

        private int GetIncomeTax()
        {
            var incomeTax = TaxRateSchedule.GetTax(AnnualSalary);
            return incomeTax;
        }

        private int GetNetIncome()
        {
            return GrossIncome - IncomeTax;
        }
    }
}