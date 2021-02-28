using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Utilities.Results;
using Core.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Core.Aspect.Autofac.Validation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;




        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            //_productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Update(product);
            return new SuccessResult(Messages.Uptated);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> getProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.getProductDetail());
        }
    }
}