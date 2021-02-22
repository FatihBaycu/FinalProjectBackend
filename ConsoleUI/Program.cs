using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
          ProductTest();
            // CategoryTest();


           
            
            Console.ReadKey();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.getProductDetail())
            {
                Console.WriteLine("Ürün Id: "+item.ProductId + "\nÜrün Stoğu: " + item.UnitsInStock+ "\nÜrün Kategorisi: " + item.CategoryName+ "\nÜrün Adı: " + item.ProductName+ "\n----------------------------------------------------");
                
            }


            //foreach (var item in productManager.GetByUnitPrice(40, 100))
            //{
            //    Console.WriteLine(item.ProductName);
            //}
        }
    }
}
