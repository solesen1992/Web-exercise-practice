using Exercise_MVCStarter.Models;

/*
 * The ICustomerAccess interface defines the contract for accessing customer data in the application. 
 * It declares two method signatures that any implementing class must provide:
 * 
 * GetAllCustomers():
 * This method is expected to return a list of all customer objects.
 * The list can be null if no customers are available, which is why the return type is marked as nullable (List<Customer>?).
 * 
 * GetCustomerById(int id):
 * This method takes an integer id as a parameter and returns a Customer object if a customer with that ID is found.
 * If no customer matches the provided ID, the method returns null.
 * 
 * Purpose of the Interface:
 * The ICustomerAccess interface is used to define the structure for classes that will handle customer data access. 
 * It enforces the implementation of two key methods: one for retrieving all customers and one for retrieving a specific customer by their ID.
 * 
 * This interface allows for flexible data access management. Different classes can implement the ICustomerAccess interface 
 * in various ways—whether by using hardcoded data (as in CustomerAccess), querying a database, or pulling data from an external service. 
 * By relying on an interface, the application can swap out different implementations of data access without needing to 
 * change other parts of the code, promoting maintainability and scalability.
 */

namespace Exercise_MVCStarter.Data
{
    // Declares an interface 'ICustomerAccess' which defines methods for accessing customer data.
    public interface ICustomerAccess
    {
        // Method signature to retrieve a list of all customers.
        // It returns a list of Customer objects, which can be null.
        List<Customer>? GetAllCustomers();

        // Method signature to retrieve a customer by their ID.
        // It returns a Customer object if found, or null if no customer is found for the given ID.
        Customer? GetCustomerById(int id);
    }
}
