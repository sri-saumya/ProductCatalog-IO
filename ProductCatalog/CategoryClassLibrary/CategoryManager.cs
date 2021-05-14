using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryClassLibrary
{
    public class CategoryManager
    {
        public string CategoryFilePath { get; }
        public CategoryManager(string s)
        {
            CategoryFilePath = s;
        }
        public void CategoryMenu()
        {
            Console.WriteLine("WELCOME TO CATEGORY MENU");
            Console.WriteLine("Select(1,2,3,4,5) : 1.GET all category || 2.SEARCH category || 3.ADD Category || 4.Delete category || 5.Exit  ");
            string Pchoice = Console.ReadLine();
            Console.WriteLine("");
            CategoryOperations co = new CategoryOperations(CategoryFilePath);

            if (Pchoice == "1")
            {
                co.GetCategory();
            }
            else if (Pchoice == "2")
            {
                co.SearchCategory();
            }
            else if (Pchoice == "3")
            {
                co.AddCategory();
            }
            else if (Pchoice == "4")
            {
                co.DeleteCategory();
            }

        }
    }
}
