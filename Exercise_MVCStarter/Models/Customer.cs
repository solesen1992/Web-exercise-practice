namespace Exercise_MVCStarter.Models
{
    public class Customer
    {
        // Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor
        public Customer(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
