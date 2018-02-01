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
    public partial class ServiceManagement : DevExpress.XtraEditors.XtraForm
    {
        public ServiceManagement()
        {
            InitializeComponent();
        }

        ServiceRepo repo = new ServiceRepo();
        ProductRepo prepo = new ProductRepo();

        private void ServiceManagement_Load(object sender, EventArgs e)
        {
            refresh();
        }

        void refresh()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = repo.getlist();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var s = new Service();
            if (s.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var serid = Convert.ToInt32(gridView1.GetFocusedRowCellValue("serviceid"));
            var type = gridView1.GetFocusedRowCellValue("Type");
            if (type.Equals("Service"))
            {
                repo.deleteservice(serid);
            }
            else
            {
                MessageBox.Show("Not a service.");
            }
            
            refresh();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var s = new BuyProduct();
            if (s.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var serid = Convert.ToInt32(gridView1.GetFocusedRowCellValue("serviceid"));
            var type = gridView1.GetFocusedRowCellValue("Type");
            var prod = gridView1.GetFocusedRowCellValue("Name").ToString();
            var qty2 = Convert.ToInt32(gridView1.GetFocusedRowCellValue("qty"));
            if (type.Equals("Product"))
            {
                prepo.returnproduct(prod,qty2);
                repo.deleteservice(serid);
            }
            else
            {
                MessageBox.Show("Not a product.");
            }
            
            refresh();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var serid = Convert.ToInt32(gridView1.GetFocusedRowCellValue("serviceid"));
            var type = gridView1.GetFocusedRowCellValue("Type");
            if (type.Equals("Service"))
            {
                repo.completeservice(serid);
            }
            else
            {
                MessageBox.Show("Not a service.");
            }
            
            refresh();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var serid = Convert.ToInt32(gridView1.GetFocusedRowCellValue("serviceid"));
            var type = gridView1.GetFocusedRowCellValue("Type");
            if (type.Equals("Product"))
            {
                repo.approveservice(serid);
            }
            else
            {
                MessageBox.Show("Not a product.");
            }

            refresh();
        }
    }
}