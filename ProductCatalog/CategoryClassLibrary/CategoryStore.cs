using CategoryClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryClassLibrary
{
    public class CategoryStore:Category
    {
        public static List<Category> categories = new List<Category>()
            {
            new Category()
            {
                Category_ID = Category.IncreamentID(),
                Name="Grocery",
                ShortCode="101",
                Description="Well Satisfied"
            },
            new Category
            {
              Category_ID = Category.IncreamentID(),
              Name="Dairy",
              ShortCode="102",
              Description="Milk Products are here"
            },
            new Category
            {
                Category_ID = Category.IncreamentID(),
                Name="Automobiles",
                ShortCode="103",
                Description="2 wheeler"
            }

        };
    }
}
