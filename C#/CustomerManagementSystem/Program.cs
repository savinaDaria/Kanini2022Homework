using System;

namespace CustomerManagementSystem
{
    class Program
    {
        //3) Create method in program class that will print  menu
        //Welcome to customer Management system(hint- use a switch case inside a do-while)
        //1) Add customers
        //2) Print customer
        //3) Print all customers
        //4) Update customer phone
        //5) Update customer age'
        //6) Exit
        //and will call the respective methods in the Manage Customer class
        void CustomerManagementSystemMenu()
        {
            int choice = 0;
            ManageCustomer manageCustomer = new ManageCustomer(3);
            Console.WriteLine("Welcome to Customer Management System Menu!\n" +                                   
                                   "1) Add customers\n" +
                                   "2) Print customer\n" +
                                   "3) Print all customers\n" +
                                   "4) Update customer phone\n" +
                                   "5) Update customer age\n" +
                                   "6) Exit");
            do
            {
                Console.WriteLine("\nPlease,choose one option: ");
                Int32.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        manageCustomer.CreateCustomer();
                        break;
                    case 2:
                        Customer customer =manageCustomer.GetCustomerById(manageCustomer.GetCustomerIdFromConsole());
                        if (customer != null) Console.WriteLine(customer); 
                        break;
                    case 3:
                        manageCustomer.GetCustomersInformation();
                        break;
                    case 4:
                        
                        if(manageCustomer.UpdateCustomerPhone())
                            Console.WriteLine("Successfully updated");                                                
                        break;
                    case 5:                        
                       if (manageCustomer.UpdateCustomerAge())
                                Console.WriteLine("Successfully updated");                         
                        break;
                    case 6:
                        Console.WriteLine("~~~~~~~~~~~~Menu Exit~~~~~~~~~~~~");
                        break;
                    default:
                        Console.WriteLine("Invalid option number. Try again");
                        break;
                }
            } while (choice!=6);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CustomerManagementSystemMenu();
        }
    }
}
