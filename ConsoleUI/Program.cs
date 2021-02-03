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
            //ProductManager productManeger = new ProductManager(new EfProductDal());

            //foreach (var product in productManeger.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}


            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(product.ProductName);
                
            }
            

        }
    }
}
