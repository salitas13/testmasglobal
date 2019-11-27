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
            List<EmployeeDTO> employeesdto = employeeRepository.GetEmployees();
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
                employees.Add(employee);
            }

            return employees;
        }
    }
}
