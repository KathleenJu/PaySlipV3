using System;
using System.Collections.Generic;

namespace PaySlip.Input
{
    class ConsoleUserInterface : IPaySlipUserInterface
    {
        public Employee GetEmployeeDetails()
        {
            Console.WriteLine("Welcome to the payslip generator!\n");
            
            Console.Write("Please input your name: ");
            var fname = Console.ReadLine();
            
            Console.Write("Please input your surname: ");
            var lname = Console.ReadLine();
            
            Console.Write("Please input your annual salary: ");
            var annualSalary = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Please input your super rate: ");
            var superRate = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Please input your payment start date: ");
            var paymentStart = Console.ReadLine();
            
            Console.Write("Please input your payment end date: ");
            var paymentEnd = Console.ReadLine();
            
            var paymentDetails = new PaymentDetails(annualSalary, superRate, paymentStart, paymentEnd);

            return new Employee(fname, lname, paymentDetails);
        }

        public void DisplayPaySlip(PaySlip paySlip)
        {
            Console.WriteLine("\nYour payslip has been generated: \n");
            
            Console.WriteLine("Name: " + paySlip.FullName);
            Console.WriteLine("Pay Period: " + paySlip.PaymentPeriod);
            Console.WriteLine("Gross Income: " + paySlip.GrossIncome);
            Console.WriteLine("Income Tax: " + paySlip.IncomeTax);
            Console.WriteLine("Net Income: " + paySlip.NetIncome);
            Console.WriteLine("Super: " + paySlip.Super);
            
            Console.WriteLine("\nThank you for using MYOB!\n");
            
        }
    }
}