using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using System.Linq;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    public class DapperDepartmentRepository: IDepartmentRepository

    {        
        //This field is used for making queries to the db
        private readonly IDbConnection _connection;
        //Constructor               
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            var depos = _connection.Query<Department>("SELECT * FROM departments");
            return depos;
        }
        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });

        }
    }
}
