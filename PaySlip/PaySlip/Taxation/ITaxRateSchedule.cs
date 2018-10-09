namespace PaySlip
{
    public interface ITaxRateSchedule
    {
        int GetTax(int annualSalary);
    }
}