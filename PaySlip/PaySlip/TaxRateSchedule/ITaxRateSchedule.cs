namespace PaySlip
{
    public interface ITaxRateSchedule
    {
        int GetIncomeTax(int annualSalary);
    }
}