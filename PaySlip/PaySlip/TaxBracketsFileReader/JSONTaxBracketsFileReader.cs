using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;

namespace PaySlip
{
    public class JSONTaxBracketsFileReader : ITaxBracketsFileReader
    {
        private string _fileContent;
        
        public JSONTaxBracketsFileReader(string filePath)
        {
            LoadFile(filePath);
        }

        public void LoadFile(string filePath)
        {
            _fileContent = File.ReadAllText(filePath);
        }

        public List<TaxBracket> GeTaxBrackets()
        {
            var taxBracketList = JsonConvert.DeserializeObject<List<TaxBracket>>(_fileContent);
            return taxBracketList;
        }
    }
}