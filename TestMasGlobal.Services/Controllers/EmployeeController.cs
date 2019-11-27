using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TestMasGlobal.Business.Factory.Interfaces;
using TestMasGlobal.Business.Services;
using TestMasGlobal.Model.Exceptions;
using TestMasGlobal.Model.Response;

namespace TestMasGlobal.Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            catch (ApiException ex)
            {
                return Task.FromResult(Request.CreateResponse<GenericResponse<string>>(HttpStatusCode.OK, new GenericResponse<string>()
                {
                    Message = ex.Message,
                    Status = (int)HttpStatusCode.NotFound
                }));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse<GenericResponse<List<Employee>>>(HttpStatusCode.OK, new GenericResponse<List<Employee>>()
                {
                    Message = "Error procesing the request.",
                    Status = (int)HttpStatusCode.InternalServerError
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
            catch(ApiException ex)
            {
                return Task.FromResult(Request.CreateResponse<GenericResponse<string>>(HttpStatusCode.OK, new GenericResponse<string>()
                {
                    Message = ex.Message,
                    Status = (int)HttpStatusCode.NotFound
                }));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse<GenericResponse<Employee>>(HttpStatusCode.OK, new GenericResponse<Employee>()
                {
                    Message = "Error procesing the request.",
                    Status = (int)HttpStatusCode.InternalServerError
                }));
            }
        }
    }
}
