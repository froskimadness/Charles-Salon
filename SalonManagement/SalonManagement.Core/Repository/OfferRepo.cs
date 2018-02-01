using SalonManagement.Core.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SalonManagement.Model.Entry;
namespace SalonManagement.Core.Repository
{
   public class OfferRepo
    {
       public string ConnectionString { get; set; }
        private IDbConnection connection { get; set; }

        public OfferRepo()
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

        public EOffer addoffer(EOffer offer)
        {
            var query = "INSERT INTO [Offer](name,Price) VALUES(@name,@Price)";

            var param = new
            {
                name = offer.Name,
                price = offer.Price,


            };

            if (connection.Execute(query, param) > 0)
            {
                return offer;
            }
            return null;
        }

        public EOffer updateoffer(EOffer offer)
        {
            var query = "UPDATE  [Offer] SET Name = @name,Price = @price WHERE offerid = @offerid";

            var param = new DynamicParameters();
            param.Add("@name", offer.Name);
            param.Add("@price", offer.Price);
            param.Add("@offerid", offer.offerid);

            if (connection.Execute(query, param) > 0)
            {
                return offer;
            }
            return null;
        }

        public List<EOffer> getlist()
        {
            var query = " SELECT * FROM [Offer] ";
            return connection.Query<EOffer>(query).ToList();
        }

       public EOffer offerdetail(string name)
       {
           var query = " SELECT * FROM [Offer] WHERE Name=@name";
           var param = new DynamicParameters();
           param.Add("@Name", name);
           try
           {
               return connection.Query<EOffer>(query, param).ToList().First();
           }
           catch (Exception)
           {
               return null;
           }
}
    }
}
