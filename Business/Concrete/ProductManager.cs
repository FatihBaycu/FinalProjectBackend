using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;

using System.Linq;
using System.Transactions;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        // claim 
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product)
        {
            //IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
            //     CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());

            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName));
            //CheckCategory(product.CategoryId);

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            //{
            //    if (CheckIfProductNameExist(product.ProductName).Success)
            //    {
            //        _
            //    }
            //}
            //return new ErrorResult();


            //ValidationTool.Validate(new ProductValidator(), product);
            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            //
        }



        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            //CheckIfProductNameExist(product.ProductName);
            //CheckIfProductCountOfCategoryCorrect(product.CategoryId);
            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            //_productDal.Update(product);
            return new SuccessResult(Messages.Uptated);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            //using (TransactionScope scope = new TransactionScope())
            //    try
            //    {
            //        Add(product);
            //        if (product.UnitPrice < 10)
            //        {
            //            throw new Exception("");
            //        }
            //        Add(product);
            //        scope.Complete();
            //    }
            //    catch (Exception e)
            //    {
            //        scope.Dispose();
            //    }

            //return null;
            // Çirkin kod yazımı bu şekilde

            Add(product);
            if (product.UnitPrice<10)
            {
                throw new Exception("");
            }

            Add(product);
            return null;
        }

        public IDataResult<List<Product>> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
        }

        //[SecuredOperation("product.add,admin")]
        [CacheAspect]
        //[PerformanceAspect(5)]
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

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> getProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.getProductDetail());
        }

        //bir kategoride en fazla 10 ürün olabilir.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {

            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 11)
            {
                return new ErrorResult(Messages.CheckIfProductCountOfCategoryCorrect);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult("Aynı isimde ürün ekleyemezsiniz.");
            }
            else
            {
                return new SuccessResult();

            }
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 5)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }

        // Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez.

    }


}