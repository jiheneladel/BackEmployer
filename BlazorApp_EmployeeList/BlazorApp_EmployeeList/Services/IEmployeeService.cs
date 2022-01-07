using EmployeeManagmentclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp_EmployeeList.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        public Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee);
        Task<HttpResponseMessage> CreateEmployee(Employee NewEmployee);
        Task DeleteEmployee(int id);
    }
}
