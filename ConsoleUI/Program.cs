using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            //productManager.GetByUnitPrice();

            foreach (var item in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(item.ProductName);
            }

            Console.ReadKey();
        }
    }
}
