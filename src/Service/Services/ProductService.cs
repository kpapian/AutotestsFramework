using Dal.Repository;
using Service.BusinessObjects;
using Service.Mappers;
using System;
using System.Linq;

namespace Service.Services
{
    public class ProductService
    {
        private ProductRepository _productRepository;

        public ProductInfo GetProductInfo()
        {
            return ProductRepository.GetProductInfo().FirstOrDefault().ToProductInfoBo();               
        }

        public ProductInfo GetProductInfoById(String productId)
        {
            return ProductRepository.GetProductInfo().FirstOrDefault().ToProductInfoBo();
        }

        public void UpdateProductInfo(ProductInfo productInfo)
        {
            ProductRepository.UpdateProductData(productInfo.ToProduct());
        }

        private ProductRepository ProductRepository => _productRepository ?? (_productRepository = new ProductRepository());

    }
}
