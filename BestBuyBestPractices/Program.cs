using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(connection);
            
            // var repo = new DepartmentRepository(connString);
            var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.Name,-20} {dept.DepartmentId}");
            }

            Console.WriteLine();

            //repo.UpdateDepartment("Notebooks", "4");
            //foreach (var dept in departments)
            //{
            //    Console.WriteLine($"{dept.Name, -20} {dept.ID}");
            //}
        }
    }
}
