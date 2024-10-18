/*
 * The ErrorViewModel class is designed to hold data that will be displayed in an error view when an error occurs in the application. 
 * 
 * Here's what the class does:
 * 
 * RequestId Property:
 * This property stores a unique identifier (as a string) for the current HTTP request.
 * The RequestId can be useful for tracking and identifying specific requests, especially when debugging or logging errors.
 * Since it is marked as nullable (string?), it can either hold a string value or be null.
 * 
 * ShowRequestId Property:
 * This is a read-only property that returns a boolean value (true or false).
 * It checks whether the RequestId property is not null and not an empty string.
 * The property will return true if RequestId contains a valid, non-empty string, and false if it is null or empty.
 * This property is typically used to determine whether the RequestId should be shown in the error view (e.g., to help users report the issue).
 * 
 * Purpose of the Class:
 * The ErrorViewModel class is part of the MVC (Model-View-Controller) pattern, specifically in the Model layer. 
 * It holds the information needed for error reporting. When an error occurs, an instance of this class is created, 
 * and the error view will use this data to display information to the user.
 * 
 * For example, in the error view, the ShowRequestId property can be used to decide whether or not to display the RequestId. 
 * The RequestId can then be shown to the user or logged for tracking purposes.
 */

namespace Exercise_MVCStarter.Models
{
    // Declares a public class 'ErrorViewModel' to represent data passed to the view in case of an error.
    public class ErrorViewModel
    {
        // A public property 'RequestId' of type string.
        // The question mark (?) indicates that this property is nullable, meaning it can hold a string or a null value.
        public string? RequestId { get; set; }

        // A public property 'ShowRequestId' that returns a boolean value (true or false).
        // This property uses an expression-bodied member (a shorthand syntax for simple get-only properties).
        // It checks if 'RequestId' is neither null nor an empty string.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
