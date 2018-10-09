using System;
using PaySlip.Input;

namespace PaySlip
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var userInterface = new ConsoleUserInterface();
            var employee = userInterface.GetEmployeeDetails();

            const string taxBracketsFilePath = "./Resources/nzTaxBrackets.json";
            var taxBracketsReader = new JSONTaxBracketsFileReader(taxBracketsFilePath);
            var taxBrackets = taxBracketsReader.GetTaxBrackets();
                
            var nzTaxRateSchedule = new NzTaxRateSchedule(taxBrackets);
            var empPaySlip = employee.GetMonthlyPaySlip(nzTaxRateSchedule);
            
            userInterface.DisplayPaySlip(empPaySlip);
        }
    }
}