using Dal.TableModel;
using Service.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappers
{
    public static class ProductMapper
    {
        public static ProductInfo ToProductInfoBo(this Product product)
        {
            if (product == null)
            {
                return null;
            }

            ProductInfo productBo = new ProductInfo();
            productBo.ProductId = product.ProductId;
            productBo.Brand = product.Brand;
            productBo.Model = product.Model;
            productBo.Price = product.Price;

            return productBo;
        }

        public static Product ToProduct(this ProductInfo productInfo)
        {
            if (productInfo == null)
            {
                return null;
            }

            Product product = new Product();
            product.ProductId = productInfo.ProductId;
            product.Brand = productInfo.Brand;
            product.Model = productInfo.Model;
            product.Price = productInfo.Price;

            return product;
        }

        public static List<ProductInfo> ToProductListBo(this List<Product> productList)
        {
            List<ProductInfo> productBoList = new List<ProductInfo>();

            foreach (Product product in productList)
            {
                productBoList.Add(ToProductInfoBo(product));
            }

            return productBoList;
        }
    }
}
