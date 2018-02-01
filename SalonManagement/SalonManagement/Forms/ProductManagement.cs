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
    public partial class ProductManagement : DevExpress.XtraEditors.XtraForm
    {
        public ProductManagement()
        {
            InitializeComponent();
        }

        ProductRepo repo = new ProductRepo();

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var p = new Product();
            if (p.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void ProductManagement_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = repo.GetList();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var p = new Product();
            p.isupdate = true;
            p.productid = Convert.ToInt32( gridView1.GetFocusedRowCellValue("product_id"));
            p.prodname = gridView1.GetFocusedRowCellValue("ProductName").ToString();
            p.tempStock = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Stock"));
            if (p.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            var p = new Product();
            p.isRestock = true;
            p.productid = Convert.ToInt32(gridView1.GetFocusedRowCellValue("product_id"));
            p.prodname = gridView1.GetFocusedRowCellValue("ProductName").ToString();
            p.tempStock = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Stock"));
            if (p.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }
    }
}