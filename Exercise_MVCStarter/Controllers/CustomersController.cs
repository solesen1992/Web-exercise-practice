using Exercise_MVCStarter.Data;
using Exercise_MVCStarter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_MVCStarter.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerAccess _customerAccess;

        public CustomersController(ICustomerAccess customerAccess)
        {
            _customerAccess = customerAccess;
        }

        // Action for the index page that shows the list of customers
        /*
         * In the Index action you must hard code a list of Customer objects 
         * and use the list as an argument in the call to the view.
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

        public IActionResult Error(EnumIdValidity validity)
        {
            return View(validity);
        }

        // Action for the details page that shows a specific customer by ID
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

        // Action to handle the search logic and display the customer details
        [HttpPost]
        public IActionResult Search(int id)
        {
            if (id <= 0)
            {
                // ID is invalid, return an error with EnumIdValidity.Invalid
                return View("Error", EnumIdValidity.Invalid);
            }

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