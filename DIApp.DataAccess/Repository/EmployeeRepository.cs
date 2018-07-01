using System;
using System.Collections.Generic;
using System.Linq;

namespace DIApp.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NORTHWNDEntities _context;

        public EmployeeRepository(NORTHWNDEntities context)
        {
            this._context = context;
        }

        public Employee GetEmployee(int id)
        {
            return this.GetEmployee(e => e.EmployeeID == id);
        }

        public Employee GetEmployee(Func<Employee, bool> predicate)
        {
            return this._context.Employees.FirstOrDefault(predicate);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this._context.Employees;
        }

        public IEnumerable<Employee> GetEmployees(Func<Employee, bool> predicate)
        {
            return this._context.Employees.Where(predicate);
        }
    }
}
