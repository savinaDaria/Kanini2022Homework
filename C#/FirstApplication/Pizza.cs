using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    //Inside class all members by default are private
    class Pizza
    {
        string[] toppings = new string[5];
        public string this[int index]//indexer??
            {
                get { return toppings[index]; }
                set { toppings[index] = value; }
            }

        public int this[string tname]
        {
            get
            {
                int idx = -1;
                for (int i = 0; i < toppings.Length; i++)
                {
                    if (toppings[i] == tname)
                    {
                        idx = i;
                        break;
                    }
                }
                return idx;
            }

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        double price;
        public double Price
            {
                get
                {
                    return price;
                }
                set
                {
                    price = value + (value * 12 / 100);
                }
            }

        //default constructor
        public Pizza()
            {
                Console.WriteLine("Pizza created");
                Name = "Check it out!!!";
            }
        //parameterized constructor
        public Pizza(string name)
            {
                Name = name;
                Console.WriteLine("Default constructor with parameter");
            }

        public Pizza(int id, string name, string desc, double price)
            {
                Id = id;
                Name = name;
                Desc = desc;
                Price = price;
            }
        public Pizza(int id, string desc, double price, string name)
            {
                Id = id;
                Name = name;
                Desc = desc;
                Price = price;
            }
        public void Bake()
        {
            Console.WriteLine("Bake for standard duration");
        }
        public void Bake(double time)
        {
            Console.WriteLine("Baked on cuztomized duration of " + time);
        }
        public void PrintPizzaDetails()
                {
                    Console.WriteLine($"The Pizza ID : {Id}");
                    Console.WriteLine($"The Pizza Name : {Name}");
                    Console.WriteLine($"The Pizza Price : {Price}");
                    Console.WriteLine($"The Pizza  : {Desc}");
                    Console.WriteLine("Toppigs are ");
                    for (int i = 0; i < toppings.Length; i++)
                    {
                        Console.WriteLine($"\t {toppings[i]}");
                    }
                }
        public static Pizza operator +(Pizza p1, Pizza p2)
        {
            Pizza newPIzza = new Pizza();
            newPIzza.Name = p1.Name + " and " + p2.Name;
            newPIzza.Price = p1.Price + p2.Price;
            for (int i = 0; i < p1.toppings.Length; i++)
            {
                newPIzza.toppings[i] = p1.toppings[i] + " " + p2.toppings[i];
            }
            return newPIzza;
        }

        public virtual void TakePizzaDetailsFromConsole()
        {
            Console.WriteLine("Please enter the pizza name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the priza price");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid entry for price. Try again");
            }
            Price = price;
            Console.WriteLine("Please enter the pizza description ");
            Desc = Console.ReadLine();
            string choice = "no";
            int cnt = 0;
            do
            {
                Console.WriteLine($"Please enter the {(cnt + 1)} topping ");
                toppings[cnt] = Console.ReadLine();
                Console.WriteLine("do you want to add another topping?? enter no to exit");
                choice = Console.ReadLine().ToLower();
                cnt++;
            } while (choice != "no" && cnt <= 4);
        }

        //public override string ToString()
        //{
        //    string topping = "";
        //    for (int i = 0; i < toppings.Length; i++)
        //    {
        //        topping += "\t " + toppings[i];
        //    }
        //    return "The Pizza ID : " + Id
        //    + "\nThe Pizza Name : " + Name
        //    + "\nThe Pizza Price : " + Price
        //    + "\nThe Pizza  : " + Desc
        //    + "\nToppigs are \n" + topping;
        //}
    }


    class Conizza : Pizza
    {
        public string Cone { get; set; }

        public override void TakePizzaDetailsFromConsole()
        {
            base.TakePizzaDetailsFromConsole();
            Console.WriteLine("Enter the cone type");
            Cone = Console.ReadLine();
        }
        public override string ToString()
        {
            return base.ToString() +
                "\n Cone " + Cone;
        }
    }
}
