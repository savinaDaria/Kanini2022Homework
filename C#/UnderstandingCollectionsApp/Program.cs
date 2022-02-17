using System;
using System.Collections;
using System.Collections.Generic;

namespace UnderstandingCollectionsApp
{
   
    class Program
    {
        void understandingSimpleCollection()
        {
            //int[] numbers = new int[3];
            //numbers[3] = 100;
            ArrayList numbers = new ArrayList();
            numbers.Add(10);
            numbers.Add(67.85f);
            numbers.Add(1045);
            numbers.Add("Hello");
            numbers.Add(new { Id = 101, Name = "Tim" });//Anon type
            numbers.Add(45.6);
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

        }

        void UnderstandingList()
        {
            List<int> numbers = new List<int>();
            numbers.Add(10);
            numbers.Add(1232);
            numbers.Add(347);
            numbers.Add(90);
            numbers.Add(56);
            numbers.Add(324);
            int sum = 0;
            foreach (var item in numbers)
            {
                sum += Convert.ToInt32(item);
            }
            numbers[2] = 101234;
            Console.WriteLine(sum);

        }
        void UnderstandingSet()
        {
            //ignores duplicates
            SortedSet<int> numbers = new SortedSet<int>();
            numbers.Add(10);
            numbers.Add(1232);
            numbers.Add(347);
            numbers.Add(90);
            numbers.Add(56);
            numbers.Add(324);
            numbers.Add(10);
            numbers.Add(10);
            int sum = 0;
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            foreach (var item in numbers)
            {
                sum += Convert.ToInt32(item);
            }
            Console.WriteLine(sum);

        }
        void MakingEmployeeList()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { Id = "E001", Name = "Tim", Salary = 12345.54 });
            employees.Add(new Employee() { Id = "E002", Name = "Jim", Salary = 65745643 });
            employees.Add(new Employee() { Id = "E003", Name = "Lim", Salary = 345453.65 });
            employees.Sort();
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.UnderstandingSet();
        }
    }
    class Employee : IComparable<Employee>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public int CompareTo(Employee other)
        {
            return this.Salary.CompareTo(other.Salary);
        }

        public override string ToString()
        {
            return Id + "\t" + Name + "\t" + Salary;
        }
    }
}
