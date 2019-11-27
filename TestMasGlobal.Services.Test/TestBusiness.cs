using NUnit.Framework;
using TestMasGlobal.Business.Services;
using TestMasGlobal.Model.Exceptions;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Employes_Founds()
        {
            // Arrange
            EmployeeService employeeService = new EmployeeService();

            // Act
            var employee = employeeService.GetAllEmployees();

            // Assert
            Assert.IsNotNull(employee);
        }
    }
}