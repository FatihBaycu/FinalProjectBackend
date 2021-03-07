using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IDataResult<List<Category>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        //Select * from Categories where CategoryId=3 gibi
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        





        //private ICategoryDal _categoryDal;

        //public CategoryManager(ICategoryDal iCategoryDal)
        //{
        //    _categoryDal = iCategoryDal;
        //}

        //public List<Category> GetAll()
        //{
        //    return _categoryDal.GetAll();
        //}

        //public Category GetById(int categoryId)
        //{
        //    return _categoryDal.Get(p => p.CategoryId == categoryId);
        //}
    }
}
