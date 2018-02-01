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
    public partial class Employee : DevExpress.XtraEditors.XtraForm
    {
        public Employee()
        {
            InitializeComponent();
        }

        public int empid { get; set; }
        public bool isupdate { get; set; }

        EmployeeRepo repo = new EmployeeRepo();

        private void Employee_Load(object sender, EventArgs e)
        {
            if (isupdate)
            {
                var emp = repo.getempdetail(empid);
                fname.Text = emp.fname;
                mname.Text = emp.mname;
                lname.Text = emp.lname;
                position.Text = emp.position;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            var emp = new EEmployee();
            emp.fname = fname.Text;
            emp.mname = mname.Text;
            emp.lname = lname.Text;
            emp.position = position.Text;
            emp.status = "Disabled";
            if (isupdate)
            {
                emp.employee_id = empid;
                repo.updateemployee(emp);
            }
            else
            {
                repo.AddEmployee(emp);
            }
            DialogResult = DialogResult.OK;
        }
    }
}