using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            
            Console.WriteLine($"Sum: {numbers.Sum()}");
            
            Console.WriteLine("------------------");

            //TODO: Print the Average of numbers
            
            Console.WriteLine($"Average: {numbers.Average()}");
            
            Console.WriteLine("------------------");
            
            //TODO: Order numbers in ascending order and print to the console
            
            var asc = numbers.OrderBy(numbers => numbers);
            foreach (var number in asc)
            {
                Console.WriteLine(number);
            }
            
            Console.WriteLine("------------------");

            //TODO: Order numbers in descending order and print to the console
            
            var desc = numbers.OrderByDescending(numbers => numbers);
            foreach (var number in desc)
            {
                Console.WriteLine(number);
            }
            
            Console.WriteLine("------------------");

            //TODO: Print to the console only the numbers greater than 6
            
            var numbersAboveSix = numbers.Where(numbers => numbers > 6).ToList();
            numbersAboveSix.ForEach(number => Console.WriteLine(number));
            
            Console.WriteLine("------------------");

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            foreach (var number in asc.Take(4))
            {
                Console.WriteLine(number);
            }
            
            Console.WriteLine("------------------");

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            numbers[4] = 24;
            foreach (var number in numbers.OrderByDescending(numbers => numbers))
            {
                Console.WriteLine(number);
            }
            
            Console.WriteLine("------------------");

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            var filtered = employees
                .Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FirstName);
            }
            
            Console.WriteLine("-------------------");
            
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            
            var overTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            foreach (var employee in overTwentySix)
            {
                Console.WriteLine($"Age: {employee.Age} Full Name: {employee.FirstName} ");
            }
            
            Console.WriteLine("-------------------");

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var yearsSum = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);
            var sumOfYOE = yearsSum.Sum(person => person.YearsOfExperience);
            Console.WriteLine($"Sum: {sumOfYOE}");
            
            Console.WriteLine("-------------------");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            
            var avgOfYOE = yearsSum.Average(person => person.YearsOfExperience);
            Console.WriteLine($"Average: {avgOfYOE}");
            
            Console.WriteLine("-------------------");

            //TODO: Add an employee to the end of the list without using employees.Add()
            
            employees = employees.Append(new Employee("John", "Doe", 24, 1)).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
