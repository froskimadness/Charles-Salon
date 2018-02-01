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
    public partial class Service : DevExpress.XtraEditors.XtraForm
    {
        public Service()
        {
            InitializeComponent();
        }

        EmployeeRepo emprepo = new EmployeeRepo();
        ServiceRepo serrepo = new ServiceRepo();
        OfferRepo ofrepo = new OfferRepo();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var ser = new EService();


            ser.Date = DateTime.Now;
            ser.Name = mservice.Text;
            ser.Type = "Service";
            ser.Price = Convert.ToInt32(sprice.Text);
            ser.Status = "Pending";
            ser.qty = 1;
            ser.employee = emp.Text;




            serrepo.addservice(ser);
            DialogResult = DialogResult.OK;
        }

        private void Service_Load(object sender, EventArgs e)
        {
            emplist(); 
            serlist();
        }

        void emplist()
        {
            emp.Properties.Items.Clear();
            foreach (var item in emprepo.GetList2())
            {
                emp.Properties.Items.Add(item.FullName);
            }
        }

        void serlist()
        {
            mservice.Properties.Items.Clear();
            foreach (var item in ofrepo.getlist())
            {
                mservice.Properties.Items.Add(item.Name);
            }
        }

        private void mservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            sprice.Text = ofrepo.offerdetail(mservice.Text).Price.ToString();
        }
    }
}