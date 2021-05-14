using CategoryClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Linq;

namespace CategoryClassLibrary
{
    public class CategoryOperations:CategoryStore
    {
        public List<Category> category { get; set; }
        public string CategoryFilePath { get; }
        public CategoryOperations(string s)
        {
            CategoryFilePath = s;
        }

        public void AddCategory()
        {
            string categoryName = "";
            while (categoryName.Length < 1)
            {
                Console.WriteLine("Enter name \nName is required");
                categoryName = Console.ReadLine();
            }
            string pCode = "";
            while (pCode.Length > 4 || pCode.Length < 1)
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
            category = new List<Category>();
            category.Add(new Category
            {
                Category_ID = categories.Count + 1,
                Name = categoryName,
                ShortCode = pCode,
                Description = desc,

            });
            categories.AddRange(category);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
            using (var writer = new StreamWriter(CategoryFilePath))
            using (CsvWriter csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CreateSpecificCulture("en-SI")))
            {
                csvWriter.WriteRecords(categories);
                Console.WriteLine("\n");
                Console.WriteLine("Added successfully");
            }
        }

        public void GetCategory()
        {
            using (StreamReader input = File.OpenText(CategoryFilePath))
            using (CsvHelper.CsvReader csvReader = new CsvHelper.CsvReader(input, System.Globalization.CultureInfo.CreateSpecificCulture("en-SI")))
            {
                IEnumerable<dynamic> records = csvReader.GetRecords<dynamic>();
                Console.WriteLine("Id\tName\tShortCode\tDescription");
                foreach (var record in records)
                {
                    Console.WriteLine(record.Category_ID + "\t" + record.Name + "\t" + record.ShortCode + "\t"
                       +  "\t\t" + record.Description );
                }
            }
        }

        public void SearchCategory()
        {
            Console.WriteLine("1 : Give ID");
            Console.WriteLine("2 : Give Name");
            Console.WriteLine("3 : Give Short Code");

            int ch3 = Convert.ToInt32(Console.ReadLine());
            switch (ch3)
            {
                case 1:
                    Console.WriteLine("Enter Id : ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    SearchByID(a);
                    break;
                case 2:
                    Console.WriteLine("Enter Name : ");
                    var name = Console.ReadLine();
                    SearchByName(name);
                    break;
                case 3:
                    Console.WriteLine("Enter Short Code : ");
                    var sc = Console.ReadLine();
                    SearchByShortCode(sc);
                    break;
            }
        }
        public static void SearchByID(int id)
        {
            var d = categories.FindAll((i) => i.Category_ID == id);
            if (d.Count > 0)
            {
                d.ForEach((i) =>
                {
                    Console.WriteLine($"{i.Category_ID} \t\t {i.Name}\t\t{i.ShortCode}\t\t{i.Description}");
                });
            }
            else
            {
                Console.WriteLine("InValid Id");
            }

        }
        public  void SearchByName(string Name)
        {
            var s = File.ReadLines(CategoryFilePath);
            foreach (var line in s)
            {
                if (line.Split(',')[1].Equals(Name))
                {
                    Console.WriteLine(line);
                    return;
                }

            }

        }
        public void SearchByShortCode(string shortCode)
        {
            var s = File.ReadLines(CategoryFilePath);
            foreach (var line in s)
            {
                if (line.Split(',')[2].Equals(shortCode))
                {
                    Console.WriteLine(line);
                    return;
                }

            }
        }


        public void DeleteCategory()
        {
            List<Category> records;
            Console.WriteLine("Enter id:");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var reader = new StreamReader(CategoryFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<Category>().ToList();
                for (int i = 0; i < records.Count; ++i)
                {
                    if (records[i].Category_ID == id)
                    {
                        records.RemoveAt(i);
                    }
                }
            }

            using (var writer = new StreamWriter(CategoryFilePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(records);
            }
        }
    }
}

