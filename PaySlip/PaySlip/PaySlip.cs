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

        public PaySlip(string name, string paymentPeriod, int annualSalary, int grossIncome, int superAnnuation,
            ITaxRateSchedule taxRateSchedule)
        {
            FullName = name;
            PaymentPeriod = paymentPeriod;
            GrossIncome = grossIncome;
            Super = superAnnuation;
            IncomeTax = GetIncomeTax(annualSalary, taxRateSchedule);
            NetIncome = GetNetIncome();
        }

        private int GetIncomeTax(int annualSalary, ITaxRateSchedule taxRateSchedule)
        {
            var incomeTax = taxRateSchedule.GetIncomeTax(annualSalary);
            return incomeTax;
        }

        private int GetNetIncome()
        {
            return GrossIncome - IncomeTax;
        }
    }
}