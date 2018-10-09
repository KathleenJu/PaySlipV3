namespace PaySlip
{
    public class TaxBracket
    {
        public int MinimumTaxableIncome { get; } 
        public int MaximumTaxableIncome { get; } 
        public int NonTaxableIncome { get; } 
        public double TaxPerDollar { get; } 
        public int ExtraTax { get; } 
        
        
        public TaxBracket(int minimumTaxableIncome, int maximumTaxableIncome, int nonTaxableIncome, double taxPerDollar, int extraTax)
        {
            MinimumTaxableIncome = minimumTaxableIncome;
            MaximumTaxableIncome = maximumTaxableIncome;
            NonTaxableIncome = nonTaxableIncome;
            TaxPerDollar = taxPerDollar;
            ExtraTax = extraTax;
        }
    }
}