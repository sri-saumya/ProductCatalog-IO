using System;

namespace ProductCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Catalog !!");
            InputManagement inputManagement = new InputManagement();
            inputManagement.input();
        }
    }
}
