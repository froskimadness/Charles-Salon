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
    public partial class Report : DevExpress.XtraEditors.XtraForm
    {
        public Report()
        {
            InitializeComponent();
        }

        ServiceRepo repo = new ServiceRepo();

        private void Report_Load(object sender, EventArgs e)
        {
            datefrom.DateTime = dateto.DateTime =Convert.ToDateTime( DateTime.Now.ToShortDateString());
            refresh();
        }

        void refresh()
        {
            var tot = 0;
            foreach (var item in repo.getserreport(datefrom.DateTime.ToShortDateString(), dateto.DateTime.ToShortDateString()))
            {
                tot += item.Price;
            }
            income.Text = tot.ToString();

            gridControl1.DataSource = null;
            gridControl1.DataSource = repo.getserreport(datefrom.DateTime.ToShortDateString(), dateto.DateTime.ToShortDateString());

            gridControl2222.DataSource = null;
            gridControl2222.DataSource = repo.getempserreport(datefrom.DateTime.ToShortDateString(), dateto.DateTime.ToShortDateString());
        }

        private void viewReportBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (datefrom.DateTime > dateto.DateTime)
            {
                MessageBox.Show("Date from cannot be over date to.") ;
                return;
            }
            refresh();
        }
    }
}