using EmployeeManagmentclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp_EmployeeList.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employee");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}");
        }

        public async Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee)
        {
            return await httpClient.PutAsJsonAsync<Employee>($"api/employee/{updatedEmployee.EmployeeId}", updatedEmployee);
        }

        public async Task<HttpResponseMessage> CreateEmployee(Employee NewEmployee)
        {
            return await httpClient.PostAsJsonAsync<Employee>("api/employee", NewEmployee);
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employee/{id}");
        }
    }
}
