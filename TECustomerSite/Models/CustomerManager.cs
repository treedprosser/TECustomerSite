namespace TECustomerSite.Models
{
    public class CustomerManager
    {
        public static void Register(Customer customer)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            db.Customers.Add(customer);
            db.SaveChanges();
        }
    }
}
