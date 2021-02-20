using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Concrete.EntityFramework
{
    //context  : Db tabloları ile proje classlarını bağlamak.
  public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@" Data Source=BAYCU;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //base.OnConfiguring(optionsBuilder);
        }
        //Önceden belirlediğimiz classlar ile veritabanıdanki tabloları eşlerştiriyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
    }
}
