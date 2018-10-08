using System;

namespace PaySlip
{
    public class PaymentDetails
    {
        private readonly string PaymentStartDate;
        private readonly string PaymentEndDate;
        
        public int AnnualSalary { get; }
        public int SuperRate { get; }
        public string PaymentPeriod { get; private set; }

        public PaymentDetails(int annualSalary, int superRate, string paymentStartDate, string paymentEndDate)
        {
            AnnualSalary = annualSalary;
            SuperRate = superRate;
            PaymentStartDate = paymentStartDate;
            PaymentEndDate = paymentEndDate;
            SetPaymentPeriod();
        }

        private void SetPaymentPeriod()
        {
            PaymentPeriod = FormatDate(PaymentStartDate) + " - " + FormatDate(PaymentEndDate);
        }
        
        private string FormatDate(string dayAndMonthDate)
        {
            var dateTime = Convert.ToDateTime(dayAndMonthDate + DateTime.Now.Year);
            var formattedDate = dateTime.ToString("dd MMMM");
            return formattedDate;
        } 
    }
}