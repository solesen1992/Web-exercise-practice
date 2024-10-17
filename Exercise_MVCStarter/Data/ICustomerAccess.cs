using Exercise_MVCStarter.Models;

namespace Exercise_MVCStarter.Data
{
    public interface ICustomerAccess
    {
        List<Customer>? GetAllCustomers();
        Customer? GetCustomerById(int id);
    }
}
