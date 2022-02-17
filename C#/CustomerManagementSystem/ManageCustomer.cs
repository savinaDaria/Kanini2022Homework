using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem
{
   // 2) Create a ManageCustomer class
   //Add Customer - Create - should add 3 customers
   //Print all customers - Read
   //Print Customer if given the ID - Read
   //Change Customer Phone - Update
   //Edit Customer Age - Update
    class ManageCustomer
    {
        public static int customer_count = 3;
        Customer[] customers = new Customer[customer_count];
        
        public virtual void CreateCustomer() //create
        {
            while (customer_count > 0)
            {
                Customer customer = new Customer();
                int id, age;
                Console.WriteLine("=========================Enter start=========================");
                customer.Id = 100+ customer_count - 1;
                Console.WriteLine("Please enter Customer Name:");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Please enter Customer Age(>0): ");
                while (!Int32.TryParse(Console.ReadLine(), out age) || age <= 0)
                {
                    Console.WriteLine("Invalid entry for age. Try again");

                }
                customer.Age = age;
                Console.WriteLine("Please enter Customer Phone:");
                customer.Phone = Console.ReadLine();
                Console.WriteLine("=========================Enter end=========================");
                customers[customer_count - 1] = customer;
                customer_count--;
            }
        }
        public void GetCustomersInformation() //read
        {
            foreach(var customer in customers)
            {
                if(customer!=null)Console.WriteLine(customer);
            }
        }
        public Customer GetCustomerById(int CustomerId) //read
        {
            foreach (var customer in customers)
            {
                if (customer!= null && customer.Id == CustomerId) return customer;
            }
            Console.WriteLine("Can`t find customer by this id.");
            return null;
        }
        public bool UpdateCustomerPhone() //update
        {
            int CustomerId= GetCustomerIdFromConsole();
            Customer customer = GetCustomerById(CustomerId);
            if (customer!=null) 
            {
                Console.WriteLine("Please enter new value for Phone: ");
                string phone = Console.ReadLine();
                customer.Phone= phone;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateCustomerAge() //update
        {
            int CustomerId = GetCustomerIdFromConsole();
            Customer customer = GetCustomerById(CustomerId);
            if (customer != null)
            {                
                int AgeUpdated;
                do
                {
                    Console.WriteLine("Please enter new value for Age: ");
                    
                } while (!Int32.TryParse(Console.ReadLine(), out AgeUpdated));
                customer.Age = AgeUpdated;
                return true;                
            }
            else
            {
                return false;
            }
        }
        public int GetCustomerIdFromConsole()
        {
            Console.WriteLine("Please, enter Customer Id: ");
            int CustomerId;
            while(!Int32.TryParse(Console.ReadLine(), out CustomerId))
            {
                Console.WriteLine("Invalid customer id.Try again");
            }
            return CustomerId;
        }
    }
}
