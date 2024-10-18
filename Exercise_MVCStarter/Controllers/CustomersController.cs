using Exercise_MVCStarter.Data;
using Exercise_MVCStarter.Models;
using Microsoft.AspNetCore.Mvc;

/*
 * This controller manages customer-related actions such as listing all customers, viewing details of a specific customer, 
 * and handling search functionality. It integrates with a customer access service (ICustomerAccess) to fetch data, and 
 * handles various error scenarios using an EnumIdValidity enum to signal different error types in the views.
 */

namespace Exercise_MVCStarter.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerAccess _customerAccess;

        /*
         * ICustomerAccess _customerAccess: This is an interface for accessing customer data. 
         * The class depends on this interface to retrieve customer information. 
         * It's injected via dependency injection in the constructor.
         */
        public CustomersController(ICustomerAccess customerAccess)
        {
            _customerAccess = customerAccess;
        }

        /*
         * Action for the index page that shows the list of customers
         * This action retrieves a list of all customers using the _customerAccess.GetAllCustomers() method and 
         * passes that list to the view for rendering the customer list on the index page.
         * 
         * The commented section shows an alternative approach where a hard-coded list of customers is used 
         * instead of fetching them from the ICustomerAccess.
         */
        public IActionResult Index()
        {
            // Use the customer list from CustomerAccess
            var customers = _customerAccess.GetAllCustomers();

            // Pass the list to the view
            return View(customers);

            /*// Hard-coded list of customers
            var customers = new List<Customer>
            {
                new Customer(1, "John", "Doe"),
                new Customer(2, "Jane", "Smith"),
                new Customer(3, "Alice", "Johnson")
            };

            // Pass the list to the view
            return View(customers);*/
        }

        /*
         * This action displays an error page based on the validity of the ID. 
         * The EnumIdValidity enum is used to specify the type of error (e.g., unspecified, not found, or invalid).
         */
        public IActionResult Error(EnumIdValidity validity)
        {
            return View(validity);
        }

        /*
         * Action for the details page that shows a specific customer by ID
         * This action handles requests to view details for a specific customer by their ID.
         * 
         * If the id parameter is null (no ID provided), it returns an error with the validity UnSpecified.
         * If no customer is found with the provided ID, it returns an error with the validity OkNotFound.
         * If a customer is found, their details are passed to the view.
         */
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                // ID is missing, return an error with EnumIdValidity.UnSpecified
                return View("Error", EnumIdValidity.UnSpecified);
            }

            // Get the customer by ID
            var customer = _customerAccess.GetAllCustomers().FirstOrDefault(c => c.Id == id.Value);

            if (customer == null)
            {
                // Customer not found, return an error with EnumIdValidity.OkNotFound
                return View("Error", EnumIdValidity.OkNotFound);
            }

            // Customer found, pass the customer details to the view
            return View(customer);
        }

        /*
         * Action to handle the search logic and display the customer details
         * 
         * This action handles customer search logic by their ID, which is sent via an HTTP POST request.
         * 
         * If the provided ID is invalid (less than or equal to 0), it returns an error with the validity Invalid.
         * If no customer is found for the given ID, it returns an error with the validity OkNotFound.
         * If the customer is found, their details are passed to the Details view.
         */
        [HttpPost]
        public IActionResult Search(int id)
        {
            if (id <= 0)
            {
                // ID is invalid, return an error with EnumIdValidity.Invalid
                return View("Error", EnumIdValidity.Invalid);
            }

            // Retrieve the list of all customers from the _customerAccess service, 
            // then search for the first customer whose Id matches the provided id.
            // If no matching customer is found, FirstOrDefault() returns null.
            var customer = _customerAccess.GetAllCustomers().FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                // No customer found with the given ID
                return View("Error", EnumIdValidity.OkNotFound);
            }

            // Customer found, pass the customer object to the Details view
            return View("Details", customer);
        }
    }
}