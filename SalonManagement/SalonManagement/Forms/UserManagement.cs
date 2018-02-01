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

namespace SalonManagement.Forms
{
    public partial class UserManagement : DevExpress.XtraEditors.XtraForm
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        UserRepo repo = new UserRepo();

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var user = new SalonUser();
            if (user.ShowDialog() == DialogResult.OK)
            {
                refreshuser();
            }
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            refreshuser();
        }

        public void refreshuser()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = repo.getlist();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var user = new SalonUser();
            user.isupdate = true;
            user.user_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("user_id"));
            if (user.ShowDialog() == DialogResult.OK)
            {
                refreshuser();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var user_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("user_id"));
            var status = gridView1.GetFocusedRowCellValue("Status");

            if (status.Equals("Disabled"))
            {
                repo.enableordisableuser(user_id, "Enabled");
            }
            if (status.Equals("Enabled"))
            {
                repo.enableordisableuser(user_id, "Disabled");
            }
            refreshuser();
        }
    }
}