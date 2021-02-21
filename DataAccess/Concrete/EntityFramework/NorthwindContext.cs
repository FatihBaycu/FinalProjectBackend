using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Concrete.EntityFramework
{
    //context  : Db tabloları ile proje classlarını bağlamak.
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Data Source = localhost; Initial Catalog = ETrade; Integrated Security = True
            optionsBuilder.UseSqlServer("Data Source = BAYCU; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        //System.IO.FileNotFoundException
        //    HResult = 0x80070002
        //Message='Microsoft.EntityFrameworkCore, Version=3.1.11.0, Culture=neutral, PublicKeyToken=adb9793829ddae60' dosyasını veya bütünleştirilmiş kodunu ya da bağımlılıklarından birini yükleyemedi.Sistem belirtilen dosyayı bulamıyor.
        //    Source=DataAccess
        //    StackTrace:

        //at DataAccess.Concrete.EntityFramework.EfProductDal.GetAll(Expression`1 filter) in C:\Users\Fatih\source\repos\FinalProject\DataAccess\Concrete\EntityFramework\EfProductDal.cs:line 21
        //at Business.Concrete.ProductManager.GetAll() in C:\Users\Fatih\source\repos\FinalProject\Business\Concrete\ProductManager.cs:line 25
        //at ConsoleUI.Program.Main(String[] args) in C:\Users\Fatih\source\repos\FinalProject\ConsoleUI\Program.cs:line 17


        //Önceden belirlediğimiz classlar ile veritabanıdanki tabloları eşlerştiriyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
