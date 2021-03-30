using System.Threading;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [SecuredOperation("product.list,admin")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(2);

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
                //return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
                //return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [SecuredOperation("product.add,admin")]
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }


         

        }

        [HttpGet("getbycategoryid")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            //var result = _productService.GetAllByCategoryId(categoryId);
            var result = _productService.GetByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
                //return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }
    }
}