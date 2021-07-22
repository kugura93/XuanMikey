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
    public partial class ChangePwd : Form
    {
        private string userId;

        public ChangePwd()
        {
            InitializeComponent();
        }

        public string UserId { get => userId; set => userId = value; }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string passWord = txtConfirm.Text;

            if(passWord.Equals(txtNew.Text) && txtConfirm.Text != "" && txtNew.Text != "")
            {
                if(Account.UpdatePassword(userId, passWord) > 0){
                    MessageBox.Show("Change Password Success!");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("New password not valid, please enter again!", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
