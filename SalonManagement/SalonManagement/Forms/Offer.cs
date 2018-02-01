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
    public partial class Offer : DevExpress.XtraEditors.XtraForm
    {
        public Offer()
        {
            InitializeComponent();
        }

        public string    name { get; set; }
        public int price { get; set; }
        public bool isupdate { get; set; }
        public int id { get; set; }

        OfferRepo repo = new OfferRepo();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var ofer = new EOffer();
            ofer.Name = sname.Text;
            ofer.Price = Convert.ToInt32( sprice.Text);
            if (isupdate)
            {
                ofer.offerid = id;
                repo.updateoffer(ofer);
            }
            else
            {
                repo.addoffer(ofer);
            }
            
            DialogResult = DialogResult.OK;
        }

        private void Offer_Load(object sender, EventArgs e)
        {
            if (isupdate)
            {
                sname.Text = name;
                sprice.Text = price.ToString();
            }
        }
    }
}