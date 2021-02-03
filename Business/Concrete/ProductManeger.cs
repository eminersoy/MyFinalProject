using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManeger : IProductService
    {
        IProductDal _productDal;   //soyut nesneyle bağlantı kuruyoruz ne inmemory ne entity framework adı geçecek

        public ProductManeger(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //Yetkisi var mı? gibi

            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoyId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
