using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryLibrary.Entities
{
    public class Category
    {
        public static int cId = 1;
       //public int C_ID { get; set; }
        public static int GeneratecategoryId()
        {
            return cId++;
        }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Desciption { get; set; }
    }
}
