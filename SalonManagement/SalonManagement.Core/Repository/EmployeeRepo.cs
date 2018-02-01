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
   public class EmployeeRepo
    {
       public string ConnectionString { get; set; }
        private IDbConnection connection { get; set; }

        public EmployeeRepo()
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

        public EEmployee AddEmployee(EEmployee employee)
        {
            var query = "INSERT INTO Employee(fname,mname,lname,position) VALUES(@fname,@mname,@lname,@position);";

            var param = new
            {
                fname = employee.fname,
                mname=employee.mname,
                lname=employee.lname,
                position = employee.position
            };

            if (connection.Execute(query, param) > 0)
            {
                return employee;
            }

            return null;
        }

        public int updateemployee(EEmployee emp)
        {
            var query = "UPDATE Employee SET fname=@fname,mname=@mname,lname=@lname,position=@position WHERE employee_id = @employee_id;";

            var param = new
            {
                employee_id = emp.employee_id,
                fname = emp.fname,
                mname = emp.mname,
                lname = emp.lname,
                position = emp.position
            };


            return connection.Execute(query, param);
        }

        public int DeleteEmployee(int employeeId)
        {
            var query = "DELETE FROM Employee WHERE employee_id = @employee_id;";

            var param = new DynamicParameters();
            param.Add("@employee_id", employeeId);

            return connection.Execute(query, param);
        }

        public List<ViewEmployee> GetList()
        {
            var query = "SELECT employee_id,fname+' '+mname+' '+lname as FullName,position as Position,Status FROM Employee";

            return connection.Query<ViewEmployee>(query).ToList();
        }

        public List<ViewEmployee> GetList2()
        {
            var query = "SELECT employee_id,fname+' '+mname+' '+lname as FullName,position as Position,Status FROM Employee WHERE Status = 'Enabled'";

            return connection.Query<ViewEmployee>(query).ToList();
        }

        public EEmployee getempdetail(int employee_id)
        {
            var query = "SELECT * FROM Employee WHERE employee_id = @employee_id";

            var param = new DynamicParameters();
            param.Add("@employee_id", employee_id);

            var list = connection.Query<EEmployee>(query, param).ToList();

            if (list.Count > 0)
            {
                return list.First();
            }

            return null;
        }

        public int enableordisableemployee(int employee_id, string status)
        {
            var query = "UPDATE [Employee] SET status = @status WHERE employee_id = @employee_id;";

            var param = new DynamicParameters();

            param.Add("@status", status);
            param.Add("@employee_id", employee_id);


            return connection.Execute(query, param);
        }
    }
}
