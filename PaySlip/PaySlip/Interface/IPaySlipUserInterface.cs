using System.Collections.Generic;

namespace PaySlip.Input
{
    public interface IPaySlipUserInterface
    {
        Employee GetEmployeeDetails();
        void DisplayPaySlip(PaySlip paySlip);
    }
}