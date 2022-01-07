using EmployeeManagmentclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp_EmployeeList.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await httpClient.GetFromJsonAsync<Department[]>("api/Departments");
        }

        public async Task<Department> GetDepartments(int id)
        {
            return await httpClient.GetFromJsonAsync<Department>($"api/Departments/{id}");
        }
    }
}
