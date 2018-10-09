using System;
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

        public PaySlip(string name, string paymentStart, string paymentEnd, int annualSalary, int grossIncome,
            int superAnnuation,
            ITaxRateSchedule taxRateSchedule)
        {
            FullName = name;
            PaymentPeriod = GetPaymentPeriod(paymentStart, paymentEnd);
            GrossIncome = grossIncome;
            Super = superAnnuation;
            IncomeTax = GetIncomeTax(annualSalary, taxRateSchedule);
            NetIncome = GetNetIncome();
        }

        private string GetPaymentPeriod(string paymentStart, string paymentEnd)
        {
            var paymentPeriod = FormatDate(paymentStart) + " - " + FormatDate(paymentEnd);
            return paymentPeriod;
        }

        private string FormatDate(string dayAndMonthDate)
        {
            var dateTime = Convert.ToDateTime(dayAndMonthDate + DateTime.Now.Year);
            var formattedDate = dateTime.ToString("dd MMMM");
            return formattedDate;
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