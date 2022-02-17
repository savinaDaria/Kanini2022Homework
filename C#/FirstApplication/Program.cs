using System;

namespace FirstApplication
{
    class Program
    {       
        
        void CreatePizza()
        {
            Pizza pizza1 =new Pizza("New York");
            pizza1.Id = 101;
            pizza1.Name = "New York";
            pizza1.Price = 12.4;
            pizza1.Desc = "blahblah blah";
            pizza1[0] = "Olives";
            pizza1[1] = "Onions";
            pizza1[2] = "Cheese";
            pizza1.PrintPizzaDetails();
            pizza1.Bake(12.4);
            Console.WriteLine("The first topping is " + pizza1[0]);
            Console.WriteLine($"The topping onnion is in the {pizza1["Onions"]} index");
            Pizza pizza2 = new Pizza(102, "Anything", 34, "Hawaii");
            pizza2[0] = "Jalapinos";
            pizza2.PrintPizzaDetails();
            Pizza p3 = pizza1 + pizza2;
            p3.PrintPizzaDetails();
        }
        void AddNewEmployee()
        {
            Employee emp1 = new Employee();
            emp1.SetEmployeeDetails();
            emp1.PrintEmployeeDetails();
            emp1.CheckHasSkill();
            emp1.ShowSkillByIndex();
            
        }

        void CreateCompany()
        {
            Company company = new Company();
            company.SetEmployeesData(3);
            company.PrintEmployeesData();
            company.FilterEmployeesBySkill();
        }

        bool IsPalindrome(int x)
        {
            if (x < Int32.MinValue || x > Int32.MaxValue)
            {
                return false;
            }
            int first_x = x;
            int reversed = 0;
            if (x.ToString()[0] == '-') return false;
            while (x > 0)
            {
                int temp_back = x % 10;
                reversed = reversed * 10 + temp_back;
                x = x / 10;
            }
            if (first_x == reversed) return true;
            return false;
        }
        static void Main(string[] args)
        {
            Cycle cycle = new MotorCycle(); //
            cycle.Name = "ABC";
            cycle.Brand = "AA-AA";
            cycle.Run();
            Console.ReadKey();
        }
    }
}
