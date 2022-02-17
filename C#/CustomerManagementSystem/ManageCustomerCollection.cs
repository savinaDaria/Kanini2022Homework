using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem
{
    class ManageCustomerCollection : ManageCustomer
    {
        Dictionary<int, Customer> customers;
        int id;
        public ManageCustomerCollection()
        {
            customers = new Dictionary<int, Customer>();
        }
        public override void CreateCustomer()
        {

            string choice = "no";
            do
            {
                Customer customer = new Customer();
                customer.TakeCustomerDetailsFromConsole();
                customer.Id = GenerateID();
                customers.Add(customer.Id, customer);
                Console.WriteLine("Do you wish to add more customers?? Enter no to exit");
                choice = Console.ReadLine().ToLower();
            } while (choice != "no");
        }

        private int GenerateID()
        {
            if (customers.Count == 0)
                return 101;
            List<Customer> lst = customers.Values.ToList();
            int cnt = lst.Count;
            int id = lst[cnt - 1].Id;
            id += 1;
            return id;
        }

        public override void PrintAllCustomers()
        {
            foreach (var item in customers.Keys)
            {
                PrintCustomer(customers[item]);
            }
        }


        //public override void PrintCustomerById()
        //{
        //    int id = TakeCustomerIdFromUser();
        //    Customer customer = GetCustomerById(id);
        //    if(customer)
        //}
        public override Customer GetCustomerById(int id)
        {
            if (customers.ContainsKey(id))
                return customers[id];
            else
                return null;
        }
        public override void RemoveCustomer()
        {
            int id = TakeCustomerIdFromUser();
            Customer customer = GetCustomerById(id);
            if (customer != null)
            {
                customers.Remove(id);
                Console.WriteLine("Custoemr deleted");
            }
            else
                Console.WriteLine("No sucg suctomer could not delete");

        }
    }

}
