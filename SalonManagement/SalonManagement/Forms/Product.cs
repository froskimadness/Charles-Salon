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
    public partial class Product : DevExpress.XtraEditors.XtraForm
    {
        public Product()
        {
            InitializeComponent();
        }

        public bool isupdate { get; set; }
        public int productid { get; set; }
        public int tempStock { get; set; }
        public bool isRestock { get; set; }
        public string prodname { get; set; }

        ProductRepo repo = new ProductRepo();

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            var product = new EProduct();
            product.ProductName = pname.Text;
            product.Stock = Convert.ToInt32(stock.Text);
            if (!price.Text.Equals(""))
            {
                product.Price = Convert.ToInt32(price.Text);
            }
            

            if (isupdate)
            {
                product.product_id = productid;
                repo.updateproduct(product);
            }
            else
            {
                if (isRestock)
                {
                    repo.AddStock(productid, tempStock, product.Stock);
                }
                else
                {
                    repo.AddProduct(product);
                }
                
            }
            DialogResult = DialogResult.OK;
        }

        private void Product_Load(object sender, EventArgs e)
        {
            if (isRestock)
            {
                mpname.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                mprice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (isupdate)
            {
                pname.Text = prodname;
                mstock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                
                stock.Text = tempStock.ToString();
            }
        }
    }
}