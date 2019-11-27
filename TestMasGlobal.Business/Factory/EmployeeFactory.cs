using TestMasGlobal.Business.Factory.Contract;
using TestMasGlobal.Business.Factory.Interfaces;

namespace TestMasGlobal.Business.Factory
{
    public class EmployeeFactory
    {
        public Interfaces.Employee CreateContract(string typeContract)
        {
            switch (typeContract)
            {
                case "HourlySalaryEmployee":
                    return new HourlySalaryEmployee();
                case "MonthlySalaryEmployee":
                    return new MonthlySalaryEmployee();
            }

            return null;
        }
    }
}
