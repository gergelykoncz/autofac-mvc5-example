using DIApp.DataAccess;
using System.Collections.Generic;

namespace DIApp.BusinessLayer.Facade
{
    public interface IEmployeeFacade
    {
        IEnumerable<Employee> GetEmployeesByCountry(string country);
        Employee GetEmployeeById(int employeeId);
        Employee GetRepForCustomer(string customerId);
        IEnumerable<string> GetEmployeeCountries();

    }
}
