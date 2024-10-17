using Exercise_MVCStarter.Models;

namespace Exercise_MVCStarter.Data
{
    public class CustomerAccess : ICustomerAccess
    {

        static List<Customer>? _customers;

        public CustomerAccess()
        {
            if (_customers == null)
            {
                _customers = new List<Customer>
            {
                new Customer(1, "Bill", "Gates"),
                new Customer(2, "Paul", "Allen"),
                new Customer(3, "Brad", "Smith"),
                new Customer(4, "Anders", "Hejlsberg")
            };
            }
        }

        public List<Customer>? GetAllCustomers()
        {
            return _customers;
        }

        public Customer? GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
