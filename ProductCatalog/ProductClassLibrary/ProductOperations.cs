using ProductClassLibrary.Entity;
using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;

namespace ProductClassLibrary
{
    public  class ProductOperations:ProductStore
    {
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

                Console.WriteLine("Id\tName\tDescription\tManufacturer\tPrice");
                foreach (var record in records)
                {

                    Console.Write(record.Id + "\t");
                    Console.Write(record.Name + "\t");
                    Console.Write(record.Description + "\t");
                    Console.Write(record.Manufacturer + "\t\t");
                    Console.WriteLine(record.SellingPrice + "\t");
                }

            }
        }
        public void AddProduct()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
            using (var writer = new StreamWriter(ProductFilePath))
            using (CsvWriter csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CreateSpecificCulture("en-SI"))) 
            {
                csvWriter.WriteRecord(products);

            }
        }
    }
}
