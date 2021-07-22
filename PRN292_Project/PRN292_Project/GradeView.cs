﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRN292_Project
{
    public partial class GradeView : Form
    {
        public GradeView()
        {
            InitializeComponent();
        }

        private void GradeView_Load(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvGrade.Rows)
            {
                row.ReadOnly = true;
            }
        }
    }
}
