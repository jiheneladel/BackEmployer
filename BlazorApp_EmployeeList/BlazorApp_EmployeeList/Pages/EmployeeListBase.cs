using BlazorApp_EmployeeList.Services;
using EmployeeManagmentclass;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_EmployeeList.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public IEnumerable<Employee> Employees { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employees = new List<Employee>();
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }


        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavigationManager.NavigateTo("/");
        }
    }

  
}
