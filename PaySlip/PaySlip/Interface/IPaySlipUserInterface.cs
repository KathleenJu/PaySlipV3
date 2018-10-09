using System.Collections.Generic;

namespace PaySlip.Input
{
    public interface IPaySlipInterface
    {
        Dictionary<string, string> GetEmployeeDetails();
        void DisplayPaySlip(PaySlip paySlip);
    }
}