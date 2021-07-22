using System;
using System.Collections;
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
    public partial class UserDetail : Form
    {
        public string studentId { get ; set ; }

        public UserDetail()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string studentName = txtName.Text.Trim();
            string fax = txtPhone.Text.Trim();
            bool gender = true;
            if (rdbFemale.Checked == true)
            {
                gender = false;
            }
            else if(rdbMale.Checked == true)
            {
                gender = true;
            }
            string address = txtAddress.Text.Trim();
            string studentEmail = txtEmail.Text.Trim();
            ArrayList list = new ArrayList()
            {
                studentName, fax, gender, address, studentEmail
            };

            if(txtAddress.Text != "" && txtEmail.Text != "" && txtName.Text != "" && txtPhone.Text != "")
            {
                if(Student.UpdateStudent(list) > 0)
                {
                    MessageBox.Show("Update Info Successfully!");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid input, please enter again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            string userId = Database.GetUserIdByStudentId(studentId);
            
            ChangePwd form = new ChangePwd();
            form.UserId = userId;
            form.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
