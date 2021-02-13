using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //atribute : bir class ile ilgili bilgi verme / onu imzalama yöntemidir. bu class ın bir controller olduğu anlamına gelir (javada annotation-javada normal parantez burda köşeli parantez)
    public class ProductsController : ControllerBase
    {

        //[HttpGet]
        //public string Get()
        //{
        //    return "Merhaba";
        //}

        //[HttpGet]
        //public List<Product> Get()
        //{
        //    return new List<Product>
        //    {
        //        new Product{ProductId=1 , ProductName = "Elma"},
        //        new Product{ProductId=2 , ProductName = "Armut"},
        //    };
        //}

        //Loosely coupled : Gevşek bağlılık (bir bağlılık var ama soyuta bağlılık. manageri değiştirirsek sorunla karşılaşmıcaz)
        //naming convention
        //IoC Container : Inversion of Control

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain : bağımlılık zinciri
           //IProductService productService = new ProductManager(new EfProductDal());  (bu satırı 36 satırı eklediğimiz için coment ettik)
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
