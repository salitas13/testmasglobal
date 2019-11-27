using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMasGlobal.DataAccess.Interfaces;
using TestMasGlobal.Model;

namespace TestMasGlobal.Business
{
    public class EmployeeBusiness
    {
        IEmployeeRepository _repository;

        public EmployeeBusiness(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public List<EmployeeDTO> GetEmployees()
        {
           return _repository.GetEmployees();
        }

        public EmployeeDTO GetEmployee(int employeeId)
        {
            return _repository.GetEmployee(employeeId);
        }
    }
}
