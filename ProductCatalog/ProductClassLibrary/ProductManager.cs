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
            Console.WriteLine("Select(1,2,3,4,5) : 1.GET all products || 2.SEARCH product by ID|| 3.ADD product || 4.DELETE product || 5.Exit");
            string Pchoice = Console.ReadLine();
            Console.WriteLine("");
            ProductOperations po = new ProductOperations(ProductFilePath);

            if (Pchoice == "1")
            {
                po.GetProducts();
            }
            else if (Pchoice == "2")
            {
                Console.WriteLine("Enter id : ");
                int id = Int32.Parse(Console.ReadLine());
                po.SearchById(id);

            }
            else if (Pchoice == "3")
            {
                po.AddProduct();
            }

            else if (Pchoice == "4")
            {
                //po.DeleteProduct();
                Console.WriteLine("Product Deleted");
            }
            else if (Pchoice == "5")
            {
                Console.WriteLine("Please try again");
            }

        }
    
    }
}
