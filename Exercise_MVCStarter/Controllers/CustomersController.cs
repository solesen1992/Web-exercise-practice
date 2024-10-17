using Exercise_MVCStarter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_MVCStarter.Controllers
{
    public class CustomersController : Controller
    {
        /*
         * In the Index action you must hard code a list of Customer objects 
         * and use the list as an argument in the call to the view.
         */
        public IActionResult Index()
        {
            // Hard-coded list of customers
            var customers = new List<Customer>
            {
                new Customer(1, "John", "Doe"),
                new Customer(2, "Jane", "Smith"),
                new Customer(3, "Alice", "Johnson")
            };

            // Pass the list to the view
            return View(customers);
        }
    }
}
