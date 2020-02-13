using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
        }

        public void UpdateDepartment(string newName, string departmentID)
        {
            _connection.Execute("UPDATE departments SET Name = (@departmentName) WHERE departmentID = (@departmentID);",
                new { departmentName = newName, departmentID = departmentID });
        }
    }
}
