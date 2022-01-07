using EmployeeManagmentclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_EmployeeList.Services
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<Department>> GetDepartments();
        public Task<Department> GetDepartments(int id);
    }
}
