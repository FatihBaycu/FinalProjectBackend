using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();




            Console.ReadKey();
        }
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            var result = productManager.getProductDetail();

            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine("Ürün Id: " + item.ProductId + "\nÜrün Stoğu: " + item.UnitsInStock + "\nÜrün Kategorisi: " + item.CategoryName + "\nÜrün Adı: " + item.ProductName + "\n----------------------------------------------------");

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }




            //foreach (var item in productManager.GetByUnitPrice(40, 100))
            //{
            //    Console.WriteLine(item.ProductName);
            //}
        }
    }
}
