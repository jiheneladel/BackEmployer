using BlazorApp_EmployeeList.Services;
using EmployeeManagmentclass;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_EmployeeList.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string DepartmentId { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.Department.DepartmentId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Employee.DepartmentId = int.Parse(DepartmentId);
            var result = await EmployeeService.UpdateEmployee(Employee);

            if (result != null)
            {
                NavigationManager.NavigateTo("/");

            }
        }

        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavigationManager.NavigateTo("/");
        }
        
    }
}
