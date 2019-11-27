using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.Model;

namespace TestMasGlobal.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        EmployeeDTO GetEmployee(int employeeId);
        List<EmployeeDTO> GetEmployees();
    }
}
