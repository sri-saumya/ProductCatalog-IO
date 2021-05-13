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

            }
            //else if (Pchoice == "3")
            //{
            //    Console.WriteLine("Enter name");
            //    var cn = Console.ReadLine();
            //    Console.WriteLine("Enter short code");
            //    var sc = Console.ReadLine();
            //    if (sc.Length <= 4)
            //    {
            //        Console.WriteLine("Enter description");
            //        var d = Console.ReadLine();
            //        Console.WriteLine("Enter selling price");
            //        var s = Int32.Parse(Console.ReadLine());
            //        if (s > 0)
            //        {
            //            ProductOperations.AddProduct(cn, sc, d, s);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Selling Price Code Should be > 0");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Source Code Should be <= 4");
            //    }


            //}
            //else if (Pchoice == "4")
            //{
            //    ProductOperations.DeleteProduct();
            //    Console.WriteLine("Product Deleted");
            //}
            //else if (Pchoice == "5")
            //{
            //    Console.WriteLine("Please try again");
            //}

        }
    
    }
}
