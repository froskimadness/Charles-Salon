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
using SalonManagement.Core.Global;

namespace SalonManagement.Forms
{
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            new EmployeeManagement().ShowDialog();
        }

        private void UserManagement_ItemClick(object sender, TileItemEventArgs e)
        {
            new UserManagement().ShowDialog();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            username.Text = LoggedUser.username;
            usertype.Text = LoggedUser.usertype;
            if (!LoggedUser.usertype.Equals("Admin"))
            {
                tools.Visible = false;
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Hide();
            new Login().ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            new ProductManagement().ShowDialog();
        }

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            new ServiceManagement().ShowDialog();
        }

        private void tileItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            new OfferManagement().ShowDialog();
        }

        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            new Report().ShowDialog();
        }
    }
}