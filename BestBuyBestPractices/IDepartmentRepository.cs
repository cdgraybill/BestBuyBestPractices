using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void UpdateDepartment(string newName, string departmentID);
        IEnumerable<Department> CreateDepartment();
    }
}
