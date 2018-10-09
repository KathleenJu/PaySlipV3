using System.Collections.Generic;

namespace PaySlip.Input
{
    public interface IInputReader
    {
        Dictionary<string, string> GetEmployeeDetails(Dictionary<string, string> inputFields);
        
    }
}