using Dal.TableModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class ProductRepository
    {
        public List<Product> GetProductInfo()
        {
            List<Product> result;

            String query = "SELECT * FROM Product";

            using (SqlConnection db = new SqlConnection(DbManager.ConnectionString))
            {
                result = db.Query<Product>(query).ToList();
            }

            return result;
        }

        public List<Product> GetProductInfoById(String productId)
        {
            List<Product> result;

            String query = $"SELECT * FROM Product WHERE ProductId = '{productId}'";

            using (SqlConnection db = new SqlConnection(DbManager.ConnectionString))
            {
                result = db.Query<Product>(query).ToList();
            }

            return result;
        }

        public void UpdateProductData(Product productData)
        {
            String query = $@"UPDATE Product 
                              SET Price = {productData.Price}
                              WHERE ProductId = '{productData.ProductId}'";

            using (SqlConnection db = new SqlConnection(DbManager.ConnectionString))
            {
                db.Execute(query);
            }
        }
    }
}
