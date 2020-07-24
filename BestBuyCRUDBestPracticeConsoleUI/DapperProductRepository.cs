using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using System.Linq;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    class DapperProductRepository : IProductRepository
    {
        //This field is used for making queries to the db
        private readonly IDbConnection _connection;
        //Constructor               
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var depos = _connection.Query<Product>("SELECT * FROM products");
            return depos;
        }
        public void InsertProduct(string newProductName, decimal newPrice, int newCatID, int newonsale, int newstocklevel)
        {
            _connection.Execute("INSERT INTO PRODUCTS " +
                "(Name, Price, CategoryID, OnSale, StockLevel)" +
                " VALUES (@productName, @price, @catid, @onsale, @stocklevel);",
                 new {productName = newProductName, 
                      price = newPrice, 
                      catid = newCatID,
                      onsale = newonsale,
                      stocklevel = newstocklevel});
        }
    }
}
