using Exercise_MVCStarter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

/*
 * The HomeController class is a basic controller in an ASP.NET Core MVC application. 
 * It handles requests for several pages (Index, Privacy, Conditions, Error) and returns corresponding views. 
 * 
 * The key points are:
 * 
 * Dependency Injection (ILogger<HomeController>): 
 * The controller uses dependency injection to receive an ILogger instance, 
 * allowing it to log information (though no logging is done explicitly in this example).
 * 
 * Index Action: 
 * This serves the homepage of the application by returning the Index view.
 * 
 * Privacy Action: 
 * This action returns a view named Privacy, typically containing privacy-related information.
 * 
 * Conditions Action: 
 * This action serves a view with conditions for purchasing products. 
 * It also adds a message to the ViewData dictionary that the view can display.
 * 
 * Error Action: 
 * This handles errors by returning an Error view. It disables response caching to ensure 
 * that error pages are never cached, and it provides an error model containing the current request's ID for troubleshooting.
 * 
 * This controller handles basic static pages for the application and includes error-handling functionality.
 */

namespace Exercise_MVCStarter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;  // Declares a private, read-only field '_logger' of type 'ILogger<HomeController>', used for logging.

        // Constructor that accepts an ILogger<HomeController> parameter and assigns it to the _logger field.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;  // The logger is passed in through dependency injection and stored in the '_logger' field.
        }

        // Action method for the Index page. It returns the 'Index' view, which is the default homepage view.
        public IActionResult Index()
        {
            return View();  // Renders the 'Index' view.
        }

        // Action method for the Privacy page. It returns the 'Privacy' view when the user navigates to /Home/Privacy.
        public IActionResult Privacy()
        {
            return View();  // Renders the 'Privacy' view.
        }

        // Action method for the Conditions page. It passes a message to the view via the ViewData dictionary.
        public IActionResult Conditions()
        {
            ViewData["Message"] = "These are the conditions for buying products.";  // Adds a message to the ViewData dictionary that can be accessed in the view.
            return View();  // Renders the 'Conditions' view.
        }

        // Action method for handling errors. It disables response caching for this action and returns the 'Error' view.
        // It passes an ErrorViewModel that includes the request ID, either from Activity or HttpContext.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Returns the 'Error' view and creates an ErrorViewModel object, setting the RequestId property to the current Activity ID or a trace identifier from the HttpContext.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
