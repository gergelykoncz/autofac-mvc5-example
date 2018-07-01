using System;
using System.Collections.Generic;

namespace DIApp.DataAccess.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        IEnumerable<Employee> GetEmployees(Func<Employee, bool> predicate);

        Employee GetEmployee(int id);

        Employee GetEmployee(Func<Employee, bool> predicate);
    }
}
