using ProductClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductClassLibrary
{
    public class ProductStore:Product
    {
        public static List<Product> products = new List<Product>()
        {
            new Product()
            {
                    ProductID = Product.IncrementId(),
                    Name = "Mobile",
                    Manufacturer = "Redemi",
                    ShortCode = "qwe",
                    Description = "RAM : 8gb, CORE : I3",
                    SellingPrice = 50000,
                   CategoryName = "Dairy"

            },
            new Product()
            {
                    ProductID = Product.IncrementId(),
                    Name = "Mouse",
                    Manufacturer = "Dell",
                    ShortCode = "rty",
                    Description = " Portable",
                    SellingPrice = 2000,
                    CategoryName = "Grocery"
            },
            new Product()
            {
                    ProductID = Product.IncrementId(),
                    Name = "Shoap",
                    Manufacturer = "Dove",
                    ShortCode = "dov",
                    Description = " Good",
                    SellingPrice = 2000,
                    CategoryName = "Grocery"
            }
        };
        
   }
}
