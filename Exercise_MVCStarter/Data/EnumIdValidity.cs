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
