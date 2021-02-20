using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
           {
               new Product{CategoryId = 1,ProductId =1,ProductName = "Bardak", UnitInStok = 15, UnitPrice = 15},
               new Product{CategoryId = 1,ProductId =2,ProductName = "Kamera", UnitInStok = 3, UnitPrice = 500},
               new Product{CategoryId = 2,ProductId =3,ProductName = "Telefon", UnitInStok = 2, UnitPrice = 1500},
               new Product{CategoryId = 2,ProductId =4,ProductName = "Klavye", UnitInStok = 65, UnitPrice = 150},
               new Product{CategoryId = 2,ProductId =5,ProductName = "Fare", UnitInStok = 1, UnitPrice = 85}
           };
        }

        public List<Product> GetAll()
        {
            return _products;

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            
            
            throw new NotImplementedException();
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate= _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.ProductId=product.ProductId;
            productToUpdate.UnitInStok=product.UnitInStok;
            productToUpdate.UnitPrice=product.UnitPrice;
        }

        public void Delete(Product product)
        {
            Product productToDelete  = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);

        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            
        }
    }
}
