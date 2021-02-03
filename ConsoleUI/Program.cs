using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManeger productManeger = new ProductManeger(new EfProductDal());

            foreach (var product in productManeger.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            //foreach (var product in productManeger.GetByUnitPrice(50,100))
            //{
            //    Console.WriteLine(product.ProductName);
            //}


        }
    }
}
