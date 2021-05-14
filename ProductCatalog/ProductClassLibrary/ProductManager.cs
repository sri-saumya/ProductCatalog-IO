using System;
using System.Collections.Generic;
using System.Text;

namespace ProductClassLibrary
{
    public class ProductManager
    {
        public string ProductFilePath { get; }
        public ProductManager(string s) 
        {
            this.ProductFilePath = s;
        }
        public void ProductMenu()
        {
            Console.WriteLine("WELCOME TO PRODUCT MENU");
            Console.WriteLine("Select(1,2,3,4) : 1.GET all products || 2.SEARCH product by Name|| 3.ADD product || 4.DELETE product ");
            string Pchoice = Console.ReadLine();
            Console.WriteLine("");
            ProductOperations po = new ProductOperations(ProductFilePath);

            if (Pchoice == "1")
            {
                po.GetProducts();
            }
            else if (Pchoice == "2")
            {   
                po.SearchProduct();
            }
            else if (Pchoice == "3")
            {
                po.AddProduct();
            }

            else if (Pchoice == "4")
            {
                po.DeleteProduct();
                Console.WriteLine("Product Deleted");
            }
            

        }
    
    }
}
