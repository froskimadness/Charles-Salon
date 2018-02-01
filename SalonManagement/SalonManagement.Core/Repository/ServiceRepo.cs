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
using SalonManagement.Model.Binder;
namespace SalonManagement.Core.Repository
{
   public  class ServiceRepo
    {
         public string ConnectionString { get; set; }
        private IDbConnection connection { get; set; }

        public ServiceRepo()
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

        public EService addservice(EService service)
        {
            var query = @"INSERT INTO Service(Date, Type, Name, Price, Status, qty, employee) 
                                      VALUES(@Date,@Type,@Name,@Price,@Status,@qty,@employee)";

            var param = new
            {
                date = service.Date,
                type = service.Type,
                name = service.Name,
                price = service.Price,
                status = service.Status,
                qty = service.qty,
                employee = service.employee

            };

            if (connection.Execute(query, param) > 0)
            {
                return service;
            }
            return null;
        }

        public int deleteservice(int serviceid)
        {
            var query = "DELETE FROM [dbo].[Service] WHERE serviceid = @serviceid";

            var param = new DynamicParameters();
            param.Add("@serviceid", serviceid);

            return connection.Execute(query, param);
        }

        public List<EService> getlist()
        {
            var query = @"SELECT *
                          FROM [dbo].[Service]";
            return connection.Query<EService>(query).ToList();
        }

        public int getsold()
        {
            var query = @"SELECT COUNT(serviceprice) sold  FROM [dbo].[Service]  WHERE [info] LIKE 'Product Sold%'";
            var list = connection.Query<tot>(query).ToList();
            if (list.Count > 0)
            {
                return list.First().sold;
            }
            return 0;
        }

        public int getservice()
        {
            var query = @"SELECT COUNT(serviceprice) service  FROM [dbo].[Service]  WHERE [info] LIKE 'Serviced by%'";
            var list = connection.Query<tot>(query).ToList();
            if (list.Count > 0)
            {
                return list.First().service;
            }
            return 0;
        }

        public int getincome()
        {
            var query = @"SELECT SUM(serviceprice) AS income FROM dbo.Service";
            var list = connection.Query<tot>(query).ToList();
            if (list.Count > 0)
            {
                return list.First().income;
            }
            return 0;
        }

        public int completeservice(int id)
        {
            var query = "UPDATE  [Service] SET Status = 'Completed' WHERE serviceid = @id";
            var param = new DynamicParameters();
            param.Add("@id",id);
            return connection.Execute(query, param);
        }

        public int approveservice(int id)
        {
            var query = "UPDATE  [Service] SET Status = 'Approved' WHERE serviceid = @id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            return connection.Execute(query, param);
        }

        public List<EService> getserreport(string from,string to)
        {
            var query = @"SELECT *
                        FROM dbo.Service
                        WHERE Status = 'Completed'
                              AND Date
                              BETWEEN @datefrom AND @dateto
                        UNION
                        SELECT *
                        FROM dbo.Service
                        WHERE Status = 'Approved'
                              AND Date
                              BETWEEN @datefrom AND @dateto;";

            var param = new DynamicParameters();
            param.Add("@datefrom", from);
            param.Add("@dateto",to);

            return connection.Query<EService>(query, param).ToList();
        }



        public List<ViewEmployeeService> getempserreport(string from, string to)
        {
            var query = @"SELECT DISTINCT employee FullName, COUNT(Price) TotalServices
                        FROM dbo.Service
                        WHERE employee != 'none' AND Date BETWEEN @datefrom AND @dateto
                        GROUP BY employee;";
            var param = new DynamicParameters();
            param.Add("@datefrom", from);
            param.Add("@dateto", to);

            return connection.Query<ViewEmployeeService>(query, param).ToList();
        }
    }
}
