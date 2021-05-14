using ProductClassLibrary.Entity;
using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;
using CategoryClassLibrary;
using CategoryClassLibrary.Entity;
using System.Linq;

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
                Console.WriteLine("Id\tName\tShortCode\tManufacture\tDescription\tPrice\t\tCATEGORY");
                foreach (var record in records)
                {
                    Console.WriteLine(record.ProductID + "\t" + record.Name + "\t" + record.ShortCode + "\t"
                       + record.Manufacturer + "\t\t" + record.Description + "\t" + record.SellingPrice+"\t"+record.CategoryName );
                }

            }
        }


        public void AddProduct()
        {
            
            string pName = "";
            while (pName.Length < 1)
            {
                Console.WriteLine("Enter name \nName is required");
                pName = Console.ReadLine();
            }
            string pCode = "";
            while(pCode.Length > 4 || pCode.Length < 1)
            {
                Console.WriteLine("Enter shortcode \nShortcode is required(0<length<5)");
                pCode = Console.ReadLine();
            }
            string desc = "";
            while (desc.Length < 1)
            {
                Console.WriteLine("Enter Description \nDescription is required");
                desc = Console.ReadLine();
            }
            string m = "";
            while (m.Length < 1)
            {
                Console.WriteLine("Enter Manufacturer \nManufacturer is required");
                m = Console.ReadLine();
            }
            int sp = 0;
            while (sp < 1)
            {
                Console.WriteLine("Enter SellingPrice \nSellingPrice > 0 is required");
                sp = Convert.ToInt32(Console.ReadLine());
            }
            CategoryOperations.categories.ForEach((i) =>
            {
                Console.WriteLine(i.Category_ID + i.Name);
            });
            List<Category> productCategories = new List<Category>();
            string choice;
            string Cname;
            do
            {
                Console.WriteLine("GIVE CATEGORY ID ");
                int id = Convert.ToInt32(Console.ReadLine());
                var data = CategoryOperations.categories.Single((a) => a.Category_ID == id);
                if (data != null)
                    productCategories.Add(data);
                Cname = data.Name;
                Console.WriteLine("Enter: no   to exit ");
                choice = Console.ReadLine();
            } while (choice == "yes");

            product = new List<Product>();
            product.Add(new Product
            {
                ProductID = products.Count + 1,
                Name = pName,
                ShortCode = pCode,
                Description = desc,
                SellingPrice = sp,
                Manufacturer=m,
                CategoryName = Cname,

            });
            products.AddRange(product);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
            using (var writer = new StreamWriter(ProductFilePath))
            using (CsvWriter csvWriter = new CsvWriter(writer, config))
            {
                csvWriter.WriteRecords(products);
                Console.WriteLine("\n");
                Console.WriteLine("Added successfully");
                writer.Flush();
            }

        }


        public void SearchProduct()
        {  
            Console.WriteLine("1 : Give Name");
            Console.WriteLine("2 : Give Short Code");

            int ch3 = Convert.ToInt32(Console.ReadLine());
            switch (ch3)
            {   
                case 1:
                    Console.WriteLine("Enter Name : ");
                    var name = Console.ReadLine();
                    SearchByName(name);
                    break;
                case 2:
                    Console.WriteLine("Enter Short Code : ");
                    var sc = Console.ReadLine();
                    SearchByShortCode(sc);
                    break;
            }
        }
        public void SearchByName(string Name)
        {
            var s = File.ReadLines(ProductFilePath);
            foreach (var line in s)
            {
                if (line.Split(',')[0].Equals(Name))
                {
                    Console.WriteLine(line);
                    return;
                }

            }
        }
        public void SearchByShortCode(string shortCode)
        {
            var s = File.ReadLines(ProductFilePath);
            foreach (var line in s)
            {
                if (line.Split(',')[1].Equals(shortCode))
                {
                    Console.WriteLine(line);
                    return;
                }

            }
        }

        public  void DeleteProduct()
        {
            List<Product> records;
            Console.WriteLine("Enter id:");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var reader = new StreamReader(ProductFilePath))
            using (var csvFile = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csvFile.GetRecords<Product>().ToList();
                for (int i = 0; i < records.Count; ++i)
                {
                    if (records[i].ProductID == id)
                    {
                        records.RemoveAt(i);
                    }
                }
            }
            using (var writer = new StreamWriter(ProductFilePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(records);
            }
        }

    }
}
