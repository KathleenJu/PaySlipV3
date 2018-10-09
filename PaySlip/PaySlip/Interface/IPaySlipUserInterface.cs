using System.Collections.Generic;

namespace PaySlip.Input
{
    public interface IPaySlipUserInterface
    {
        Dictionary<string, string> GetEmployeeDetails();
        void DisplayPaySlip(PaySlip paySlip);
    }
}