using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalonManagement.Core.Repository;
using SalonManagement.Core.Global;

namespace SalonManagement.Forms
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();

        }

        UserRepo repo = new UserRepo();

        private void Lgn_Click(object sender, EventArgs e)
        {

            login();
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            
        }

        void login()
        {
            var user_id = repo.login(Username.Text, Password.Text);
            if (user_id > 0)
            {
                var user = repo.getuserdetail(user_id);
                LoggedUser.user_id = user.user_id;
                LoggedUser.username = user.username;
                LoggedUser.usertype = user.usertype;
                LoggedUser.status = user.status;
                if (LoggedUser.status.Equals("Enabled"))
                {
                    Hide();
                    new Dashboard().ShowDialog();
                }
                else
                {
                    MessageBox.Show("User is disabled ");
                }


            }
            else
            {
                MessageBox.Show("Incorrect Username or Password ");
            }
        }
    }
}