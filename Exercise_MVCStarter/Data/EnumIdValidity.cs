/*
 * The EnumIdValidity enum is used to classify the status or validity of a customer ID. 
 * 
 * It defines four possible states:
 * 
 * UnSpecified: Indicates that no ID was provided or the ID is missing in the request.
 * Ok: Represents a valid ID, and a customer was successfully found with that ID.
 * OkNotFound: Represents a valid ID, but no customer was found that matches the given ID.
 * Invalid: Indicates that the provided ID is invalid, for example, when the ID is not a number or is outside the expected range.
 * 
 * This enum is likely used in error handling or validation logic when dealing with customer-related operations, 
 * such as searching for a customer by ID. It helps differentiate between various ID-related issues and provides clear feedback for the application flow.
 */

namespace Exercise_MVCStarter.Data
{
    public enum EnumIdValidity
    {
        UnSpecified,   // ID is missing
        Ok,            // ID is valid and customer found
        OkNotFound,    // ID is valid but customer not found
        Invalid        // ID is invalid (e.g., not an integer)
    }
}
