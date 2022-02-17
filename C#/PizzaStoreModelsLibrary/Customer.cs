using System;

namespace PizzaStoreModelsLibrary
{
    public class Customer
    {
        string phone;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone
        {
            get
            {
                string maskedPhone = "******" + phone.Substring(6, 4);
                return maskedPhone;
            }
            set { phone = value; }
        }

        //public string Phone { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string name, int age, string phone)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
        }

        public override string ToString()
        {
            return "Customer ID : " + Id
                + "\nCustomer Name : " + Name
               + "\nCustomer Age : " + Age
               + "\nCustomer Phone : " + Phone;
        }

        public void TakeCustomerDetailsFromConsole()
        {
            int age;
            Console.WriteLine("Please enter Customer Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter Customer Age(>0): ");
            while (!Int32.TryParse(Console.ReadLine(), out age) || age <= 0)
            {
                Console.WriteLine("Invalid entry for age. Try again");

            }
            Age = age;
            Console.WriteLine("Please enter Customer Phone:");
            do
            {
                Console.WriteLine("Please enter Customer Phone:");
                Phone = Console.ReadLine();

            } while (Phone.Length!=10);
            
        }
    }

    public class UnderstandAccess
    {
        private int intPrivate;
        public int intPublic;
        protected int intProtected;
        internal int intInternal;
    }
}
