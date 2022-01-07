using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPAPI.Model.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
    }
}
