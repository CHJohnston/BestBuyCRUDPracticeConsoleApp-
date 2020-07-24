using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    class ConsoleLogging
    {
        public static void DisplayMenu()
        {
            //This method Displays the User Selection Menu 
            Console.WriteLine();
            Console.WriteLine("Welcome to the Best Buy Database Application");
            Console.WriteLine("1 - List the Departments Table");
            Console.WriteLine("2 - Add a new Department");
            Console.WriteLine("3 - List the Products Table");
            Console.WriteLine("4 - Add a new Product");         
            Console.WriteLine("5 - End Application");
        }
        public static void PrintDept(IEnumerable<Department> depos)
        {
            Console.WriteLine();
            Console.WriteLine("Departments Table");
            foreach (var depo in depos)
            {
                Console.WriteLine($"ID: {depo.DepartmentID} Name: {depo.Name}");
            }
        }
        public static void PrintProducts(IEnumerable<Product> productrepos)
        {
            Console.WriteLine();
            Console.WriteLine("Products Table");
            foreach (var p in productrepos)
            {
                Console.WriteLine($"ID: {p.ProductID} CategoryID: {p.CategoryID} " +
                    $" OnSale: {p.OnSale} StockLevel {p.StockLevel} Price: {p.Price} Name: {p.Name}");
            }
        }
    }
}
