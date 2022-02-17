using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem
{
    //1) Create a customer class
    //Id, Name, Age, Phone
    class Customer
    {
        int id, age;
        public int Id { get { return id; } set { id = value; } }
        public string Name { get; set; }
        public int Age { get { return age; } set { age = value; } }
        public string Phone { get; set; }
        public Customer()
        {
            Id = 0;
            Name = "Unknown";
            Age = 0;
            Phone = "";
        }

        public override string ToString()
        {
            return "\n==============Customer Details==============\n" +
              "\nCustomer Id: " + Id +
              "\nCustomer Name: " + Name+
              "\nCustomer Age: " + Age+
              "\nCustomer Phone: " + Phone+ "\n";
        }
        
    }
}
