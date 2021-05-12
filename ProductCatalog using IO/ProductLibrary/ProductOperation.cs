using ProductLibrary.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;



namespace ProductLibrary
{
    public class ProductOperation
    {
        public static void GetProduct()
        {
            string dirPath = @"C:\Users\lenovo\OneDrive - Taazaa Tech Pvt Ltd\Desktop\training\ProductCatalog1";
            string filePath = @"C:\Users\lenovo\OneDrive - Taazaa Tech Pvt Ltd\Desktop\training\ProductCatalog1/Product.csv";
            using (StreamReader input = File.OpenText(filePath))
            using (CsvHelper.CsvReader csvreader = new CsvHelper.CsvReader(input, System.Globalization.CultureInfo.CreateSpecificCulture("en-SI")))
            {
                IEnumerable<Product> products = csvreader.GetRecords<Product>();
                foreach (Product record in products)
                {
                    Console.WriteLine(record.P_ID);
                    Console.WriteLine(record.Name);
                    Console.WriteLine(record.Manufacturer);
                    Console.WriteLine(record.ProductCategory);
                    Console.WriteLine(record.SellingPrice);
                    Console.WriteLine(record.ShortCode);
                    Console.WriteLine(record.Description);
                }
            }
        }

        public static void AddProduct()
        {

            string choice;
            List<Product> data = new List<Product>();
            do
            {
                string filepath = @"C:/productcatalog/product.csv";


                Console.WriteLine("Please enter product name: ");
                Console.WriteLine("name is a required field ");
                string name = Console.ReadLine();

                Console.WriteLine("Please enter description: ");

                Console.WriteLine("description is a required field ");
                string description = Console.ReadLine();

                Console.WriteLine("Please enter product manufacturer: ");

                Console.WriteLine("manufacturer is a required field ");
                string manufacturer = Console.ReadLine();
                Console.WriteLine("Please enter product price: ");

                Console.WriteLine("price must be  greater than 0 ");
                int price = Convert.ToInt32(Console.ReadLine());
                using (StreamWriter input = new StreamWriter(filepath))
                using (CsvHelper.CsvWriter csvwriter = new CsvHelper.CsvWriter(input, System.Globalization.CultureInfo.CreateSpecificCulture("en-SI")))
                {
                    Product p = new Product { P_ID = Product.pId, Name = name, Description = description, Manufacturer = manufacturer, SellingPrice = price };
                    data.Add(p);

                    csvwriter.WriteHeader<Product>();
                    csvwriter.NextRecord();

                    csvwriter.WriteRecords(data);

                    input.Flush();
                }

                Console.WriteLine("Add another product?(yes/no)");
                choice = Console.ReadLine();



            } while (choice == "yes");
        }
    }
}
