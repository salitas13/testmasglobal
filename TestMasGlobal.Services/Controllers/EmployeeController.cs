using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestMasGlobal.Business.Factory.Interfaces;
using TestMasGlobal.Business.Services;
using TestMasGlobal.Model.Response;

namespace TestMasGlobal.Services.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employees
        public Task<HttpResponseMessage> Get()
        {
            try
            {
                EmployeeService employeeService = new EmployeeService();

                var employees = employeeService.GetAllEmployees();

                return Task.FromResult(Request.CreateResponse<GenericResponse<List<Employee>>>(HttpStatusCode.OK, new GenericResponse<List<Employee>>()
                {
                    Result = employees,
                    Status = (int)HttpStatusCode.OK
                }));
            }
            catch (Exception)
            {
                return Task.FromResult(Request.CreateResponse<GenericResponse<List<Employee>>>(HttpStatusCode.OK, new GenericResponse<List<Employee>>()
                {
                    Message = "Error al intentar procesar la solicitud, intente mas tarde",
                    Status = (int)HttpStatusCode.BadRequest
                }));
            }
        }

        // GET: api/Employees/5
        public Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                EmployeeService employeeService = new EmployeeService();

                var employee =  employeeService.GetEmployee(id);

                return Task.FromResult(Request.CreateResponse<GenericResponse<Employee>>(HttpStatusCode.OK, new GenericResponse<Employee>()
                {
                    Result = employee,
                    Status = (int)HttpStatusCode.OK
                }));
            }
            catch (Exception)
            {
                return Task.FromResult(Request.CreateResponse<GenericResponse<Employee>>(HttpStatusCode.OK, new GenericResponse<Employee>()
                {
                    Message = "Error al intentar procesar la solicitud, intente mas tarde",
                    Status = (int)HttpStatusCode.BadRequest
                }));
            }
        }
    }
}
