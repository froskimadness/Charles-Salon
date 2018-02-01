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
    public partial class OfferManagement : DevExpress.XtraEditors.XtraForm
    {
        public OfferManagement()
        {
            InitializeComponent();
        }

        OfferRepo repo = new OfferRepo();

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var p = new Offer();
            if (p.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var p = new Offer();
            p.isupdate = true;
            p.id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("offerid"));
            p.name = gridView1.GetFocusedRowCellValue("Name").ToString();
            p.price = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Price"));
            if (p.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void OfferManagement_Load(object sender, EventArgs e)
        {
            refresh();
        }

        void refresh()
        {

            gridControl1.DataSource = null;
            gridControl1.DataSource = repo.getlist();
        }

        private void offerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}