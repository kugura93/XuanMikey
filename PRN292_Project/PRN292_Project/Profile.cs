using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PRN292_Project.DAO;

namespace PRN292_Project
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void refreshDgvGrade()
        {
            dgvGrade.DataSource = null;
            dgvGrade.DataSource = Grade.GetAllGrade(lblStudentId.Text);
            dgvGrade.Columns[4].HeaderText = "Grade";
            foreach (DataGridViewRow row in dgvGrade.Rows)
            {
                row.ReadOnly = true;
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            refreshDgvGrade();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            UserDetail form = new UserDetail();
            string sql = "select * from Student where StudentId = '" + lblStudentId.Text + "'";
            DataTable dt = Database.GetDataBySql(sql);
            if(dt.Rows.Count > 0)
            {
                form.txtName.Text = dt.Rows[0]["StudentName"].ToString();
                form.txtPhone.Text = dt.Rows[0]["Fax"].ToString();
                form.txtAddress.Text = dt.Rows[0]["Address"].ToString();
                form.txtEmail.Text = dt.Rows[0]["StudentEmail"].ToString();
                if(Convert.ToBoolean(dt.Rows[0]["Gender"]) == true)
                {
                    form.rdbMale.Checked = true;
                }
                else
                {
                    form.rdbFemale.Checked = true;
                }
            }
            form.studentId = lblStudentId.Text;
            form.ptrProfile.Image = Image.FromFile("C:\\Users\\HLC\\source\\repos\\PRN292_Project\\PRN292_Project\\Image\\ptr.png");
            form.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
