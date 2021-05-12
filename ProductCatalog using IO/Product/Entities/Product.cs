using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog_Category.Entities;
namespace ProductCatalog_Product.Entities
{
    public class Product
    {
        public int Product_ID { get; set; }
        public string Name { get; set; }
        public string ProductManufacturer { get; set; }
        public int SellingPrice { get; set; }
        public List<Category> ProductCategory { get; set; }
    }
}

