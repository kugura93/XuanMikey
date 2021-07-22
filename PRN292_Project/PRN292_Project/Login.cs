using PRN292_Project.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace PRN292_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public bool validAccount()
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (user == "" || pass == "")
            {
                return false;
            }
            Regex regex = new Regex(@"^([a-zA-Z0-9_\.]+)$");
            if (!regex.IsMatch(user) || !regex.IsMatch(pass))
            {
                return false;
            }

            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();

            if (validAccount())
            {
                //string sql = "select * from Account where Username = '" + Username + "' and Password = '" + Password + "' and RoleId = " + cbbRole.SelectedValue;
                //if (Database.GetDataBySql(sql).Rows.Count > 0)
                if(Account.GetAccount(Username, Password, Convert.ToInt32(cbbRole.SelectedValue)).Count > 0)
                {
                    if (Convert.ToInt32(cbbRole.SelectedValue) == 1)
                    {
                        //Manager form
                    }
                    if (Convert.ToInt32(cbbRole.SelectedValue) == 2)
                    {
                        //Teacher form
                    }
                    if (Convert.ToInt32(cbbRole.SelectedValue) == 3)
                    {
                        
                        this.Hide();
                        StudentForm form = new StudentForm();
                        form.lblStudentName.Text = Database.GetUserId(Username, Password, Convert.ToInt32(cbbRole.SelectedValue));
                        form.ShowDialog();
                        this.Close();
                        
                    }
                }
                else
                {
                    MessageBox.Show("This account not exist or no permission!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid Account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cbbRole.DataSource = Role.GetRoles();
            cbbRole.DisplayMember = "RoleName";
            cbbRole.ValueMember = "RoleId";
        }
    }
}
