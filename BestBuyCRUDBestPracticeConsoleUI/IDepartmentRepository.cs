using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    public interface IDepartmentRepository
    {   //Saying we need a method called GetAllDepartments that conforms to IEnumerable
        IEnumerable<Department> GetAllDepartments(); //Stubbed out method
        void InsertDepartment(string deptname);
    }
}
