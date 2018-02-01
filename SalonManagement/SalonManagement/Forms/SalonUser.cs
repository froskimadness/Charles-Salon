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
using SalonManagement.Model.Entry;
namespace SalonManagement.Forms
{
    public partial class SalonUser : DevExpress.XtraEditors.XtraForm
    {
        public SalonUser()
        {
            InitializeComponent();
        }

        public bool isupdate { get; set; }
        public int user_id { get; set; }

        UserRepo repo = new UserRepo();

        private void save_Click(object sender, EventArgs e)
        {
            var user = new User();
            user.username = username.Text;
            user.password = password.Text;
            user.usertype = usertype.Text;
            user.status = "Disabled";
            if (isupdate)
            {
                user.user_id = user_id;
                repo.updateuser(user);
            }
            else
            {
                
                repo.adduser(user);
            }
            DialogResult = DialogResult.OK;
        }

        private void SalonUser_Load(object sender, EventArgs e)
        {
            if (isupdate)
            {
                var user = repo.getuserdetail(user_id);
                username.Text = user.username;
                password.Text = user.password;
                usertype.Text = user.usertype;
            }
        }
    }
}