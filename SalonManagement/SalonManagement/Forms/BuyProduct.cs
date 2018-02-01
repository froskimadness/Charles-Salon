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
using SalonManagement.Model.Entry;
using SalonManagement.Core.Repository;

namespace SalonManagement.Forms
{
    public partial class BuyProduct : DevExpress.XtraEditors.XtraForm
    {
        public BuyProduct()
        {
            InitializeComponent();
        }
        ServiceRepo repo = new ServiceRepo();
        ProductRepo prepo = new ProductRepo();
        private void prod_SelectedIndexChanged(object sender, EventArgs e)
        {

                pprice.Text = (prepo.getproductdetail(prod.Text).Price).ToString();
                stock.Text = prepo.getproductdetail(prod.Text).Stock.ToString();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (prepo.getproductdetail(prod.Text).Stock == 0)
            {
                MessageBox.Show("Out of stock.");
                return;
            }
            if (prepo.getproductdetail(prod.Text).Stock < Convert.ToInt32(qty.Text))
            {
                MessageBox.Show("Cannot go over the stock limit.");
                return;
            }

            

            var ser = new EService();


            ser.Date = DateTime.Now;
            ser.Type = "Product";
            ser.Name = prod.Text;
            ser.Price = prepo.getproductdetail(prod.Text).Price * Convert.ToInt32(qty.Text);
            ser.Status = "Pending";
            ser.qty = Convert.ToInt32(qty.Text);
            ser.employee = "none";
            
            

            prepo.deductproduct(prod.Text, Convert.ToInt32(qty.Text));

            repo.addservice(ser);
            DialogResult = DialogResult.OK;
        }

        private void BuyProduct_Load(object sender, EventArgs e)
        {
            foreach (var item in prepo.GetList())
            {
                prod.Properties.Items.Add(item.ProductName);
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                bill.Text = (prepo.getproductdetail(prod.Text).Price * Convert.ToInt32(qty.Text)).ToString();
            }
            catch (Exception E)
            {
                bill.Text = E.Message;
            }
        }
    }
}