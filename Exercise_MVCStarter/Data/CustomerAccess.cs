using Exercise_MVCStarter.Models;

namespace Exercise_MVCStarter.Data
{
    /*
     * The CustomerAccess class is responsible for managing customer data and provides methods to retrieve that data. 
     * It implements the ICustomerAccess interface, which likely defines the required methods like GetAllCustomers() and GetCustomerById(int id).
     * 
     * Static List of Customers: 
     * The class uses a static list, _customers, which holds hardcoded customer data. The static nature of the list 
     * means that it is shared across all instances of the CustomerAccess class. This ensures that 
     * the same customer list is used whenever this class is accessed.
     * 
     * Constructor (CustomerAccess): 
     * The constructor checks if the _customers list has already been initialized. 
     * If it hasn't (i.e., it's null), the constructor creates the list and populates it with some hardcoded Customer objects. 
     * This ensures that the list of customers is only initialized once.
     * 
     * GetAllCustomers Method: 
     * This method simply returns the entire list of customers. 
     * It allows other parts of the application to retrieve the full list.
     * 
     * GetCustomerById Method: 
     * This method searches the _customers list for a specific customer by their unique ID. 
     * It uses FirstOrDefault, which returns the first customer that matches the condition (c.Id == id), or null if no match is found.
     * 
     * Purpose:
     * The CustomerAccess class provides a basic, static way to access customer data, primarily for demonstration purposes. 
     * It simulates data access by hardcoding a few customers and offers methods to retrieve all customers or 
     * find a specific customer by ID. This class is likely a mock implementation that would be replaced with 
     * more complex data access logic (e.g., database access) in a real application.
     */

    public class CustomerAccess : ICustomerAccess
    {

        // Declares a static list of Customer objects, initially set to null.
        // The list is shared among all instances of the class because it is static.
        static List<Customer>? _customers;

        // Constructor for the 'CustomerAccess' class.
        // It initializes the list of customers if it hasn't been initialized yet.
        public CustomerAccess()
        {
            // If the _customers list is null (hasn't been initialized), create a new list and add hardcoded Customer objects to it.
            if (_customers == null)
            {
                _customers = new List<Customer>  // Initializes a new list of customers with some hardcoded values.
                {
                    new Customer(1, "Bill", "Gates"),      // Adds Bill Gates to the list with ID 1.
                    new Customer(2, "Paul", "Allen"),      // Adds Paul Allen to the list with ID 2.
                    new Customer(3, "Brad", "Smith"),      // Adds Brad Smith to the list with ID 3.
                    new Customer(4, "Anders", "Hejlsberg") // Adds Anders Hejlsberg to the list with ID 4.
                };
            }
        }

        // Method to retrieve the full list of customers.
        public List<Customer>? GetAllCustomers()
        {
            // Returns the list of customers (_customers).
            return _customers;
        }

        // Method to retrieve a customer by their unique ID.
        public Customer? GetCustomerById(int id)
        {
            // Searches the _customers list for a customer with the specified ID.
            // It returns the first match or null if no customer with that ID is found.
            return _customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
