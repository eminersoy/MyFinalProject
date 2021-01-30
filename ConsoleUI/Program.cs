using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManeger productManeger = new ProductManeger(new InMemoryProductDal());

            foreach (var product in productManeger.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            
        }
    }
}
