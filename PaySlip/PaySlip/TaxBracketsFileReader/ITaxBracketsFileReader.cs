using System.Collections.Generic;

namespace PaySlip
{
    public interface ITaxBracketsFileReader
    {
        void LoadFile(string filePath);
        List<TaxBracket> GetTaxBrackets();
    }
}