using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<Product> GetById(int productId);
        IDataResult<List<ProductDetailDto>> getProductDetail();
        IResult Add(Product product);
        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);


        // data içerenleri IDataResult<List<Product>> metotIsmi -- diye     örnek:      IDataResult<List<Product>> GetAll();
        //data içermeyen metotları ise IResult metotIsmi(Entity entitiy)    örnek:      IResult Add(Product product);

    }
}
