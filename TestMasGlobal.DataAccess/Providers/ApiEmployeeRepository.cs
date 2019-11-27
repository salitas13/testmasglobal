using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using TestMasGlobal.DataAccess.Interfaces;
using TestMasGlobal.Model;

namespace TestMasGlobal.DataAccess.Providers
{
    public class ApiEmployeeRepository : IEmployeeRepository
    {
        private static string baseUrl = ConfigurationManager.AppSettings["WebApi"];

        private static string GetStringAsync(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 10000;
            request.ContentType = "application/json; charset=utf-8";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());

            return reader.ReadToEnd(); ;
        }

        public List<EmployeeDTO> GetEmployees()
        {
            if (baseUrl == null)
            {
                return null;
            }

            var employeeJson = GetStringAsync(baseUrl);
            // Here I use Newtonsoft.Json to deserialize JSON string to Employee object
            var employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(employeeJson);
            return employees;
        }

        public EmployeeDTO GetEmployee(int employeeId)
        {
            var employees = GetEmployees();

            if (employees != null)
            {
                return employees.Where(t => t.Id == employeeId).FirstOrDefault();
            }

            return null;

        }
    }
}
