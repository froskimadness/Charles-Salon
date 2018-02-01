using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using SalonManagement.Model.Entry;
using SalonManagement.Model.Binder;
using SalonManagement.Core.Global;
namespace SalonManagement.Core.Repository
{
    public class UserRepo : IDisposable
    {
        public string ConnectionString { get; set; }
        private IDbConnection connection { get; set; }

        public UserRepo()
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

        public User adduser(User user)
        {
            var query = "INSERT INTO [User](username,password,usertype,status) VALUES(@username,@password,@usertype,@status)";

            var param = new
            {
                username = user.username,
                password = user.password,
                usertype = user.usertype,
                status = user.status


            };

            if (connection.Execute(query, param) > 0)
            {
                return user;
            }
            return null;
        }

        public User updateuser(User user)
        {
            var query = "UPDATE  [User] SET username = @username,password = @password,usertype = @usertype,status = @status WHERE user_id = @user_id";

            var param = new DynamicParameters();
            param.Add("@username",user.username);
             param.Add("@password",user.password);
             param.Add("@usertype",user.usertype);
             param.Add("@status",user.status);
             param.Add("@user_id", user.user_id);

            if (connection.Execute(query, param) > 0)
            {
                return user;
            }
            return null;
        }

        public int enableordisableuser(int user_id,string status)
        {
            var query = "UPDATE [User] SET status = @status WHERE user_id = @user_id;";

            var param = new DynamicParameters();
            
            param.Add("@status", status);
            param.Add("@user_id", user_id);


            return connection.Execute(query, param);
        }

        public List<ViewUser> getlist()
        {
            var query = " SELECT user_id,username AS Username,password AS Password,usertype AS UserType,status AS Status FROM [User] ";
            return connection.Query<ViewUser>(query).ToList();
        }

        public int login(String username, String password)
        {
            var query = "SELECT * FROM [User] WHERE username = @Username AND password = @Password";
            var param = new DynamicParameters();
            param.Add("@Username",username);
            param.Add("@Password",password);
            var list = connection.Query<User>(query, param).ToList();

            if (list.Count > 0)
            {
                return list.First().user_id;
            }
            return 0;
        }

        public User getuserdetail(int user_id)
        {
            var query = "SELECT * FROM [User] WHERE user_id = @user_id ";
            var param = new DynamicParameters();
            param.Add("@user_id", user_id);
            return connection.Query<User>(query, param).ToList().First();
        }
    }
}
