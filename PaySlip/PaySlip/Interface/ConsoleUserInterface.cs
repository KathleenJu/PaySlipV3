using System;
using System.Collections.Generic;

namespace PaySlip.Input
{
    public class ConsoleInterface : IPaySlipInterface
    {
        public Dictionary<string, string> GetEmployeeDetails(Dictionary<string, string> inputFields)
        {
            var employeeDetails = new Dictionary<string, string>();
            Console.Write("Welcome to the payslip generator! \n");
            foreach (var field in inputFields)
            {
                Console.Write(field.Value);
                employeeDetails.Add(field.Key, Console.ReadLine());
            }

            return employeeDetails;
        }
    }
}