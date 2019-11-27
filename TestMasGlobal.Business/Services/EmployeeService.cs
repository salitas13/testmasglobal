using AutoMapper;
using System.Collections.Generic;
using TestMasGlobal.Business.Factory;
using TestMasGlobal.Business.Factory.Interfaces;
using TestMasGlobal.DataAccess.Providers;
using TestMasGlobal.Model;
using TestMasGlobal.Model.Exceptions;

namespace TestMasGlobal.Business.Services
{
    public class EmployeeService
    {
        public Employee GetEmployee(int id)
        {
            EmployeeBusiness employeeRepository = new EmployeeBusiness(new ApiEmployeeRepository());
            EmployeeDTO employeeDto = employeeRepository.GetEmployee(id);

            if (employeeDto == null)
            {
                throw new ApiException("Employee not found.");
            }

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
            EmployeeBusiness employeeRepository = new EmployeeBusiness(new ApiEmployeeRepository());
            List<EmployeeDTO> employeesDto = employeeRepository.GetEmployees();
            List<Employee> employees = new List<Employee>();

            EmployeeFactory contractFactory = new EmployeeFactory();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
            });

            IMapper iMapper = config.CreateMapper();

            if (employeesDto != null)
            {
                foreach (var employeeDto in employeesDto)
                {
                    Employee employee = contractFactory.CreateContract(employeeDto.ContractTypeName);

                    iMapper.Map<EmployeeDTO, Employee>(employeeDto, employee);

                    employee.CalculateSalary();
                    employees.Add(employee);
                }
            }

            return employees;
        }
    }
}
