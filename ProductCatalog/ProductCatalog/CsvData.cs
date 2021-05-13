using CategoryClassLibrary;
using ProductClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductCatalog_
{
    public class CsvData
    {
        string productCsvPath = @"C:\Users\lenovo\OneDrive - Taazaa Tech Pvt Ltd\Desktop\training\ProductCatalog\ProductCatalog\CsvFiles\product.csv";
        string categoryCsvPath = @"C:\Users\lenovo\OneDrive - Taazaa Tech Pvt Ltd\Desktop\training\ProductCatalog\ProductCatalog\CsvFiles\category.csv";
        
        public void input()
        {
            //File.Create(productCsvPath + "/product.csv");
            //File.Create(categoryCsvPath + "/product.csv");

            Console.WriteLine("\tPRODUCT  CATALOG");
            Console.WriteLine("");
            while (true)
            {

                Console.WriteLine("ENTER : Category || Product || Exit : ");
                string choice = Console.ReadLine();
                Console.WriteLine("");

                if (choice.ToUpper() == "PRODUCT")
                {
                    ProductManager productManager = new ProductManager(productCsvPath);
                    productManager.ProductMenu();
                }
                if (choice.ToUpper() == "CATEGORY")
                {
                    CategoryManager categoryManager = new CategoryManager(categoryCsvPath);
                    categoryManager.CategoryMenu();
                }
                if (choice.ToUpper() == "EXIT")
                {
                    Console.WriteLine("THANKYOU  !!");
                    break;
                }

            }
        }


    }
}
