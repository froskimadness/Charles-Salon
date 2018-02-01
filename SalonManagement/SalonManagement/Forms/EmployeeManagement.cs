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
    public partial class EmployeeManagement : DevExpress.XtraEditors.XtraForm
    {
        public EmployeeManagement()
        {
            InitializeComponent();
        }

        EmployeeRepo repo = new EmployeeRepo();

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var emp = new Employee();
            if (emp.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var emp = new Employee();
            emp.isupdate = true;
            emp.empid = Convert.ToInt32(gridView1.GetFocusedRowCellValue("employee_id"));
            if (emp.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void EmployeeManagement_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = repo.GetList();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("employee_id"));
            repo.DeleteEmployee(id);
            refresh();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var user_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("employee_id"));
            var status = gridView1.GetFocusedRowCellValue("Status");

            if (status.Equals("Disabled"))
            {
                repo.enableordisableemployee(user_id, "Enabled");
            }
            if (status.Equals("Enabled"))
            {
                repo.enableordisableemployee(user_id, "Disabled");
            }
            refresh();
        }
    }
}