using SalonManagement.Core.Global;
using SalonManagement.Model.Entry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace SalonManagement.Core.Repository
{
   public class ProductRepo
    {
        public string ConnectionString { get; set; }
        private IDbConnection connection { get; set; }

        public ProductRepo()
        {
            ConnectionString = Connection.ConnectionString;
            if (!string.IsNullOrWhiteSpace(ConnectionString))
            {
                connection = new SqlConnection(ConnectionString);
            }

        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
            }

        }

        public EProduct AddProduct(EProduct product)
        {
            var query = "INSERT INTO Product(ProductName,Stock,Price) VALUES(@ProductName,@Stock,@Price);";

            var param = new
            {
                ProductName = product.ProductName,
                Stock = product.Stock,
                Price = product.Price
            };

            if (connection.Execute(query, param) > 0)
            {
                return product;
            }

            return null;
        }

        public int AddStock(int productid, int oldstack, int addstock)
        {
            var query = "UPDATE Product SET Stock = @Stock WHERE product_id = @product_id;";
            var tot = oldstack + addstock;
            var param = new DynamicParameters();
            param.Add("@product_id", productid);
            param.Add("@Stock", tot);
            if (connection.Execute(query, param) > 0)
            {
                return tot;
            }

            return 0;
        }

        public int updateproduct(EProduct product)
        {
            var query = "UPDATE Product SET ProductName=@ProductName,Price=@Price WHERE product_id = @product_id;";


            var param = new DynamicParameters();
            param.Add("@product_id", product.product_id);
            param.Add("@ProductName", product.ProductName);
            param.Add("@Price", product.Price);

            return connection.Execute(query, param);
        }

        public List<EProduct> GetList()
        {
            var query = "SELECT * FROM Product";

            return connection.Query<EProduct>(query).ToList();
        }

        public EProduct getproductdetail(string product)
        {
            var query = @"SELECT *
                        FROM [dbo].[Product]
                        WHERE ProductName = @Product;";
            var param = new DynamicParameters();
            param.Add("@Product",product);
            var list = connection.Query<EProduct>(query,param).ToList();
            if (list.Count > 0)
            {
                return list.First();
            }
            return null;
        }

        public int deductproduct(string product,int qty)
        {
            var temp = getproductdetail(product).Stock - qty;
            var query = "UPDATE Product SET Stock=@Stock WHERE product_id = @product_id;";
            var param = new DynamicParameters();
            param.Add("@Stock", temp);
            param.Add("@product_id", getproductdetail(product).product_id);
            return connection.Execute(query, param);
        }

        public int returnproduct(string product, int qty)
        {
            var temp = getproductdetail(product).Stock + qty;
            var query = "UPDATE Product SET Stock=@Stock WHERE product_id = @product_id;";
            var param = new DynamicParameters();
            param.Add("@Stock", temp);
            param.Add("@product_id", getproductdetail(product).product_id);
            return connection.Execute(query, param);
        }
    }
}
