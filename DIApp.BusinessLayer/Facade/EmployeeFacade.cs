using System.Collections.Generic;
using System.Linq;
using DIApp.DataAccess;
using DIApp.DataAccess.Repository;

namespace DIApp.BusinessLayer.Facade
{
    public class EmployeeFacade : IEmployeeFacade
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;

        public EmployeeFacade(IEmployeeRepository employeeRepository, ICustomerRepository customerRepository)
        {
            this._employeeRepository = employeeRepository;
            this._customerRepository = customerRepository;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return this._employeeRepository.GetEmployee(employeeId);
        }

        public IEnumerable<string> GetEmployeeCountries()
        {
            return this._employeeRepository.GetEmployees().Select(e => e.Country).Distinct();
        }

        public IEnumerable<Employee> GetEmployeesByCountry(string country)
        {
            return this._employeeRepository.GetEmployees(e => e.Country == country);
        }

        public Employee GetRepForCustomer(string customerId)
        {
            return this._customerRepository.GetCustomer(customerId).Orders.First().Employee;
        }
    }
}
