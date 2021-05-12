using ProductCategoryLibrary;
using ProductLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog
{
    public class InputManagement
    {
        public void input()
        {
            Console.WriteLine("\t PRODUCT  CATALOG");
            Console.WriteLine("");

            ProductOperation po = new ProductOperation();
            CategoryOperation co = new CategoryOperation();



            while (true)
            {

                Console.WriteLine("ENTER : Category || Product || Exit : ");
                string choice = Console.ReadLine();
                Console.WriteLine("");


                if (choice.ToUpper() == "PRODUCT")
                {
                    Console.WriteLine("Select(1,2,3,4,5) : 1.GET all products || 2.SEARCH product by ID|| 3.ADD product || 4.DELETE product || 5.Exit");
                    string Pchoice = Console.ReadLine();
                    Console.WriteLine("");

                    if (Pchoice == "1")
                    {
                        ProductOperation.GetProduct();

                    }
                    else if (Pchoice == "2")
                    {
                        Console.WriteLine("Enter id : ");
                        int id = Int32.Parse(Console.ReadLine());
                        //po.SearchById(id);

                    }
                    else if (Pchoice == "3")
                    {
                        ProductOperation.AddProduct();
                    }

                }



                if (choice.ToUpper() == "CATEGORY")
                {

                    Console.WriteLine("Select(1,2,3,4,5) : 1.GET all category || 2.SEARCH category || 3.ADD Category || 4.Delete category || 5.Exit  ");
                    string Pchoice = Console.ReadLine();
                    Console.WriteLine("");

                    if (Pchoice == "1")
                    {
                        //CategoryOperation.ListOfAllCategories();


                    }
                    else if (Pchoice == "2")
                    {
                        //CategoryOperation.SearchCategory();

                    }

                }

                if (choice.ToUpper() == "EXIT")
                {
                    Console.WriteLine("THANKYOU  !!");
                    break;
                }


            }
        }
    }
}
