using Eticaret.Core.Dtos.Response;
using Eticaret.Core.Models;
using Eticaret.Core.Services;
using Eticaret.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicaret.BussinessLayer.Concrete
{
    public class ProductService : Service<Product>, IProductService
    {

        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal, IGenericDal<Product> genericDal) : base(genericDal)
        {
            _productDal = productDal;
        }


    

    }
}
