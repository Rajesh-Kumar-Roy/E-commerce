using System;
using System.Collections.Generic;
using System.Text;
using Bootstrap.Manager.Base;
using Bootstrap.Manager.IContract;
using Bootstrap.Repositories.Contract;
using Bootstrap1.Models;

namespace Bootstrap.Manager
{
    public class ProductManger:BaseManager<Product>,IProductManager
    {
        private IProductRepository _productRepository;
        public ProductManger(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<Product> GetAllProductsWithCategory()
        {
            return _productRepository.GetAllProductsWithCategory();
        }

        public ICollection<Product> GetAllWonemProduct()
        {
            return _productRepository.GetAllWonemProduct();
        }

        public ICollection<Product> GetAllMenProduct()
        {
            return _productRepository.GetAllMenProduct();
        }
    }
}
