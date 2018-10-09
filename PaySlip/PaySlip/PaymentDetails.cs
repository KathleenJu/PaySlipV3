using System;
using System.Collections.Generic;

namespace PaySlip
{
    public class PaymentDetails
    {
        private readonly string PaymentStartDate;
        private readonly string PaymentEndDate;
        
        public int AnnualSalary { get; }
        public int SuperRate { get; }

        public PaymentDetails(int annualSalary, int superRate, string paymentStartDate, string paymentEndDate)
        {
            AnnualSalary = annualSalary;
            SuperRate = superRate;
            PaymentStartDate = paymentStartDate;
            PaymentEndDate = paymentEndDate;
        }

        public string GetPaymentPeriod()
        {
            var paymentPeriod = FormatDate(PaymentStartDate) + " - " + FormatDate(PaymentEndDate);
            return paymentPeriod;
        }

        private string FormatDate(string dayAndMonthDate)
        {
            var dateTime = Convert.ToDateTime(dayAndMonthDate + DateTime.Now.Year);
            var formattedDate = dateTime.ToString("dd MMMM");
            return formattedDate;
        }

        public int GetGrossIncome()
        {
            var monthlySalary = AnnualSalary / 12;
            return (int) Math.Round((double) monthlySalary);
        }

        public int GetSuperAnnuation()
        {
            var superRateDecimal = (double) SuperRate / 100;
            var superAnnuation = GetGrossIncome() * superRateDecimal;
            return (int) superAnnuation;
        }
    }
}