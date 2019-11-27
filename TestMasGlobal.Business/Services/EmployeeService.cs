using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMasGlobal.Business.Factory;
using TestMasGlobal.Business.Factory.Interfaces;
using TestMasGlobal.Model;

namespace TestMasGlobal.Business.Services
{
    public class EmployeeService
    {
        public Employee GetEmployee(int id)
        {
            EmployeeDTO employeeDto = new EmployeeDTO();
            EmployeeFactory contractFactory = new EmployeeFactory();
            Employee employee = contractFactory.CreateContract(employeeDto.ContractTypeName);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
            });
            IMapper iMapper = config.CreateMapper();

            iMapper.Map<EmployeeDTO, Employee>(employeeDto, employee);

            employee.CalculateSalary();

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            List<EmployeeDTO> employeesdto = new List<EmployeeDTO>();
            List<Employee> employees = new List<Employee>();

            EmployeeFactory contractFactory = new EmployeeFactory();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
            });

            IMapper iMapper = config.CreateMapper();

            foreach (var employeedto in employeesdto)
            {
                Employee employee = contractFactory.CreateContract(employeedto.ContractTypeName);

                iMapper.Map<EmployeeDTO, Employee>(employeedto, employee);

                employee.CalculateSalary();
            }

            return employees;
        }
    }
}
