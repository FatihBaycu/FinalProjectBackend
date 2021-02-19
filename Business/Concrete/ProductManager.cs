using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _iProductDal;

        public ProductManager(IProductDal iProductDal)
        {
            _iProductDal = iProductDal;
        }
        


        public List<Product> GetAll()
        {
            return _iProductDal.GetAll();   
        }
    }
}
