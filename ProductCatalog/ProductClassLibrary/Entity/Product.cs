using CategoryClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductClassLibrary.Entity
{
    public class Product
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int SellingPrice { get; set; }

        public string CategoryName { get; set; }
        public List<Category> Category;

        public static int ID = 1;
        public int ProductID { get; set; }
        public static int IncrementId()
        {
            return ID++;
        }

        public Product()
        {
            this.Category = new List<Category>();
        }
    }
}
