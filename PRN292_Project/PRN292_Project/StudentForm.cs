using PRN292_Project.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRN292_Project
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            string sql = "select StudentId, StudentName, StudentEmail from Student where UserId = '" + lblStudentName.Text + "'";
            DataTable dt = Database.GetDataBySql(sql);

            Profile profile = new Profile();
            
            if(dt.Rows.Count > 0)
            {
                profile.lblStudentId.Text = dt.Rows[0]["StudentId"].ToString();
                profile.lblStudentName.Text = dt.Rows[0]["StudentName"].ToString();
                profile.lblEmail.Text = dt.Rows[0]["StudentEmail"].ToString();
            }
            profile.ptrProfile.Image = Image.FromFile("C:\\Users\\HLC\\source\\repos\\PRN292_Project\\PRN292_Project\\Image\\ptr.png");
            profile.ShowDialog();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            refreshDgvClass();

            cbbSearch.SelectedIndex = 0;
        }
       
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void refreshDgvClass()
        {
            string studentId = Database.GetStudentId(lblStudentName.Text);

            dgvClass.Columns.Clear();
            dgvClass.DataSource = null;
            dgvClass.DataSource = Class.GetClassTaken(studentId);
            dgvClass.Columns.RemoveAt(4);
            dgvClass.Columns["ClassId"].ReadOnly = true;
            dgvClass.Columns["TeacherId"].ReadOnly = true;
            dgvClass.Columns["CourseId"].ReadOnly = true;
            dgvClass.Columns["ClassName"].ReadOnly = true;
            DataGridViewButtonColumn click = new DataGridViewButtonColumn();
            click.Name = "btnViewGrade";
            click.HeaderText = "Option";
            click.Text = "Grade";
            click.ValueType = typeof(System.Windows.Forms.Button);
            click.UseColumnTextForButtonValue = true;
            dgvClass.Columns.Insert(4, click);
        }

        private void refreshDgvClass(string search)
        {
            dgvClass.Columns.Clear();
            dgvClass.DataSource = null;
            if (cbbSearch.SelectedIndex == 0)
            {
                dgvClass.DataSource = Class.GetClassByClassId(search);
            }
            else if (cbbSearch.SelectedIndex == 1)
            {
                dgvClass.DataSource = Class.GetClassByCourseId(search);
            }
            else if (cbbSearch.SelectedIndex == 2)
            {
                dgvClass.DataSource = Class.GetClassByTeacherId(search);
            }
            else if (cbbSearch.SelectedIndex == 3)
            {
                dgvClass.DataSource = Class.GetClassByClassName(search);
            }
            dgvClass.Columns.RemoveAt(4);
            dgvClass.Columns["ClassId"].ReadOnly = true;
            dgvClass.Columns["TeacherId"].ReadOnly = true;
            dgvClass.Columns["CourseId"].ReadOnly = true;
            dgvClass.Columns["ClassName"].ReadOnly = true;
            DataGridViewButtonColumn click = new DataGridViewButtonColumn();
            click.Name = "btnViewGrade";
            click.HeaderText = "Option";
            click.Text = "Grade";
            click.ValueType = typeof(System.Windows.Forms.Button);
            click.UseColumnTextForButtonValue = true;
            dgvClass.Columns.Insert(4, click);
        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex != dgvClass.Columns["btnViewGrade"].Index)
            {
                return;
            }
            else
            {
                string classId = dgvClass[0, e.RowIndex].Value.ToString();
                string courseId = dgvClass[1, e.RowIndex].Value.ToString();
                string studentId = Database.GetStudentId(lblStudentName.Text);

                GradeView view = new GradeView();
                view.dgvGrade.DataSource = null;
                view.dgvGrade.DataSource = Grade.GetCourseGrade(classId, courseId, studentId);
                view.dgvGrade.Columns[4].HeaderText = "Grade";
                view.ShowDialog();
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refreshDgvClass(txtSearch.Text);
        }
    }
}
