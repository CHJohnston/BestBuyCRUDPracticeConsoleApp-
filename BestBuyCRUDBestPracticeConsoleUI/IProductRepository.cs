using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    public interface IProductRepository
    {
        //Saying we need a method called GetAllProducts that conforms to IEnumerable
        IEnumerable<Product> GetAllProducts(); //Stubbed out method
        public void InsertProduct(string productname, decimal price, int catID, int onsale, int stocklevel);     
    }
}
