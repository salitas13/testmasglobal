using TestMasGlobal.Model;

namespace TestMasGlobal.Business.Factory.Contract
{
    public class MonthlySalaryEmployee : Interfaces.Employee
    {
        private const int MONTHS = 12;

        public override void CalculateSalary()
        {
            this.AnnualSalary = this.MonthlySalary * MONTHS;
        }
    }
}
