using Microsoft.AspNetCore.Mvc.Rendering;

namespace TECustomerSite.Models
{
    public class CustomerManager
    {
        // Register the customer after info has been filled in and verified
        public static void Register(Customer customer)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public static List<Customer> GetCustomers()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            List<Customer> customers = db.Customers.ToList();
            return customers;
        }

        /// <summary>
        /// find customer with id
        /// </summary>
        /// <param name="id">id of the customer to find</param>
        /// <returns>customer with this id or null if doesn't exist</returns>
        public static Customer FindCustomer(int id)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            Customer customer = db.Customers.Find(id);
            return customer;
        }

        /// <summary>
        /// update customer with given id with new customer data 
        /// </summary>
        /// <param name="id">id of customer to update</param>
        /// <param name="newCustomer">new data values</param>
        public static async void UpdateCustomer(int id, Customer newCustomer)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            Customer customer = db.Customers.Find(id);
             //Customer customer = new Customer();  // customer to update 
            // copy over new customer data 
            customer.CustFirstName      = newCustomer.CustFirstName;
            customer.CustLastName       = newCustomer.CustLastName;
            customer.CustAddress        = newCustomer.CustAddress;
            customer.CustCity           = newCustomer.CustCity;
            customer.CustProv           = newCustomer.CustProv;
            customer.CustPostal         = newCustomer.CustPostal;
            customer.CustCountry        = newCustomer.CustCountry;
            customer.CustHomePhone      = newCustomer.CustHomePhone;
            customer.CustBusPhone       = newCustomer.CustBusPhone;
            customer.CustEmail          = newCustomer.CustEmail;
            customer.Username           = newCustomer.Username;
            customer.Password           = newCustomer.Password;
            db.Customers.Update(customer);
            db.SaveChanges();

        }
    }
}
