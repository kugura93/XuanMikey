using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LoginGUI
{
    public partial class LoginInput : Form
    {
        public LoginInput()
        {
            InitializeComponent();
        }

        public bool validAccount()
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();
            if (user == "" || pass == "")
                return false;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\.]+)$");
            if (!regex.IsMatch(user) || !regex.IsMatch(pass))
                return false;
            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();
        }
    }
}
