using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class Menu
    {
        Pizza[] pizzas = new Pizza[3];
        public Menu()
        {
            for (int i = 0; i < pizzas.Length; i++)
            {
                pizzas[i] = new Pizza();
                pizzas[i].TakePizzaDetailsFromConsole();
            }
        }
        public void PrintMenu()
        {
            foreach (var item in pizzas)
            {
                //item.PrintPizzaDetails();
                Console.WriteLine(item);
                Console.WriteLine("------------------------------");
            }
        }
    }
}
