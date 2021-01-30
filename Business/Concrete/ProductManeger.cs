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
    }
}
