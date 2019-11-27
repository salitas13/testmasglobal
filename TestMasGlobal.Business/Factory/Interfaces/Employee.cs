using TestMasGlobal.Model;

namespace TestMasGlobal.Business.Factory.Interfaces
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public object RoleDescription { get; set; }
        public int HourlySalary { get; set; }
        public int MonthlySalary { get; set; }

        public abstract double CalculateSalary();
    }
}
