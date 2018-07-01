using System.Linq;

namespace DIApp.DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NORTHWNDEntities _context;

        public CustomerRepository(NORTHWNDEntities context)
        {
            this._context = context;
        }

        public Customer GetCustomer(string id)
        {
            return this._context.Customers.FirstOrDefault(x => x.CustomerID == id);
        }
    }
}
