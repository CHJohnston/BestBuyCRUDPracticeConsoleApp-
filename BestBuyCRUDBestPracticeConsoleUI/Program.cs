using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            // Check DB connection
            // Console.WriteLine(connString);
            IDbConnection conn = new MySqlConnection(connString);
            #endregion

            //Select the SQL Departments Table and load it into the IEnumerable depos
            DapperDepartmentRepository deptrepo = new DapperDepartmentRepository(conn);
            var depos = deptrepo.GetAllDepartments();

            //Select the SQL Products Table and load it into the IEnumerable products
            DapperProductRepository productrepo = new DapperProductRepository(conn);
            var products = productrepo.GetAllProducts();
                                

            //Dispaly the menu and ask the user to select an option   
            string userSelection;
            bool stopAppliction = false;
            while (stopAppliction == false)
            {
                ConsoleLogging.DisplayMenu();
                Console.WriteLine();
                Console.Write("Please enter your selection: ");
                userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1": //Print All Departments
                        depos = deptrepo.GetAllDepartments();
                        ConsoleLogging.PrintDept(depos);
                        break;
                    case "2": //Add a New Department
                        Console.Write("Enter the Department Name: ");
                        deptrepo.InsertDepartment(Console.ReadLine());                        
                        break;
                    case "3": //Print All Products
                        products = productrepo.GetAllProducts();
                        ConsoleLogging.PrintProducts(products);                      
                        break;
                    case "4": //Add a New Product  
                        Console.Write("Enter the Product Name: ");
                        string pName = Console.ReadLine();
                        Console.Write("Enter the Product Price: ");
                        decimal pprice = Decimal.Parse(Console.ReadLine());
                        Console.Write("Enter the Product CategoryID: ");
                        int pCategoryID = int.Parse(Console.ReadLine());
                        Console.Write("Enter 1 if OnSale or 0 if Not: ");
                        int pOnSale = int.Parse(Console.ReadLine());
                        Console.Write("Enter Stock Level: ");
                        int pStockLevel = int.Parse(Console.ReadLine());
                        productrepo.InsertProduct(pName, pprice, pCategoryID, pOnSale, pStockLevel);                        
                        break;
                    case "5":
                        stopAppliction = true;
                        break;
                }
            }
            Console.WriteLine("Ending Best Buy Database Application");
        }        
    }
}
