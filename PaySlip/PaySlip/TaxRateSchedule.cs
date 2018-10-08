namespace PaySlip
{
    public class TaxRateSchedule
    {
        public int MinimumTaxableIncome { get; } 
        public int MaximumTaxableIncome { get; } 
        public int NonTaxableIncome { get; } 
        public int TaxPerDollar { get; } 
        public int ExtraTax { get; } 
        
        
        public TaxRateSchedule(int minimumTaxableIncome, int maximumTaxableIncome, int nonTaxableIncome, int taxPerDollar, int extraTax)
        {
            MinimumTaxableIncome = minimumTaxableIncome;
            MaximumTaxableIncome = maximumTaxableIncome;
            NonTaxableIncome = nonTaxableIncome;
            TaxPerDollar = taxPerDollar;
            ExtraTax = extraTax;
        }
    }
}