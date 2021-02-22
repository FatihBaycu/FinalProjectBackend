using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
       
            ICategoryDal _categoryDal;
            public CategoryManager(ICategoryDal categoryDal)
            {
                _categoryDal = categoryDal;
            }
            public List<Category> GetAll()
            {
                //İş kodları
                return _categoryDal.GetAll();
            }

            //Select * from Categories where CategoryId=3 gibi
            public Category GetById(int categoryId)
            {
                return _categoryDal.Get(c => c.CategoryId == categoryId);
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
