using ProductClassLibrary.Entity;
using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;

namespace ProductClassLibrary
{
    public class ProductOperations : ProductStore
    {
        public List<Product> product { get; set; }
        public string ProductFilePath { get; }
        public ProductOperations(string inputFilePath)
        {
            this.ProductFilePath = inputFilePath;
        }


        public void GetProducts()
        {
            using (StreamReader input = File.OpenText(ProductFilePath))
            using (CsvHelper.CsvReader csvReader = new CsvHelper.CsvReader(input, System.Globalization.CultureInfo.CreateSpecificCulture("en-SI")))
            {
                IEnumerable<dynamic> records = csvReader.GetRecords<dynamic>();
                Console.WriteLine("calling get product");
                Console.WriteLine("Id\tName\tShortCode\tManufacture\tDescription\tPrice");
                foreach (var record in records)
                {
                    Console.WriteLine(record.ProductID + "\t" + record.Name + "\t" + record.ShortCode + "\t"
                       + record.Manufacturer + "\t\t" + record.Description + "\t" + record.SellingPrice + "\t");
                }

            }
        }
        public void AddProduct()
        {   
            string pName = Console.ReadLine();
            string pCode = Console.ReadLine();
            string desc = Console.ReadLine();
            string m = Console.ReadLine();
            int sp = Convert.ToInt32(Console.ReadLine());

            product = new List<Product>();
            product.Add(new Product
            {
                ProductID = Product.ID,
                Name = pName,
                ShortCode = pCode,
                Description = desc,
                SellingPrice = sp,
                Manufacturer=m,
                //Category = productCategories,

            });
            products.AddRange(product);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
            using (var writer = new StreamWriter(ProductFilePath))
            using (CsvWriter csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CreateSpecificCulture("en-SI")))
            {
                csvWriter.WriteRecords(products);
                Console.WriteLine("\n");
                Console.WriteLine("Added successfully");
            }
        }

        public void SearchById(int id)
        {
            var d = products.FindAll((i) => i.ProductID == id);
            if (d.Count > 0)
            {
                d.ForEach((i) =>
                {
                    Console.WriteLine($"{i.ProductID} \t\t {i.Name}\t\t{i.Manufacturer}\t\t{i.Description}\t\t{i.SellingPrice}");
                });
            }
            else
            {
                Console.WriteLine("Id Not Found");
            }
        }



    }
}
