namespace PaySlip.Tests
{
    public class PaymentDetails
    {
        public int _annualSalary { get; }
        public int _superRate { get; }
        public string _paymentStartDate { get; }
        public string _paymentEndDate { get; }

        public PaymentDetails(int annualSalary, int superRate, string paymentStartDate, string paymentEndDate)
        {
            _annualSalary = annualSalary;
            _superRate = superRate;
            _paymentStartDate = paymentStartDate;
            _paymentEndDate = paymentEndDate;
        }
    }
}