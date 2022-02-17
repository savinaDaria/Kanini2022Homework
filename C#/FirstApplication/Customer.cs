using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public void Details()
        {
            Console.WriteLine("Details");
            Console.WriteLine("Name: "+Name);
            Console.WriteLine("Age: "+Age);
            Console.WriteLine("Phone: "+Phone);
        }
    }
}
