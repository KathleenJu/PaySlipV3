using System;
using PaySlip.Input;

namespace PaySlip
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var ui = new ConsoleUserInterface();
            var employee = ui.GetEmployeeDetails();

            const string taxBracketsFilePath = "/Users/kathleen.jumamoy/Projects/PaySlipV3/PaySlip/PaySlip/Resources/nzTaxBrackets.json";
            var taxBracketsReader = new JSONTaxBracketsFileReader(taxBracketsFilePath);
            var taxBrackets = taxBracketsReader.GeTaxBrackets();
                
            var nzTaxRateSchedule = new NzTaxRateSchedule(taxBrackets);
            var empPaySlip = employee.GetMonthlyPaySlip(nzTaxRateSchedule);
            
            ui.DisplayPaySlip(empPaySlip);
        }
    }
}