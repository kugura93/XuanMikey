using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PRN292_Project.DAO
{
    class Course
    {
        private string courseId;
        private string courseName;

        public Course()
        {
        }

        public Course(string courseId, string courseName)
        {
            this.CourseId = courseId;
            this.CourseName = courseName;
        }

        public string CourseId { get => courseId; set => courseId = value; }
        public string CourseName { get => courseName; set => courseName = value; }

        internal static List<Course> GetAllCourse()
        {

            List<Course> courses = new List<Course>();
            DataTable dt = Database.GetDataBySql("select * from Course");
            foreach (DataRow data in dt.Rows)
            {
                string courseId = data["CourseId"].ToString();
                string courseName = data["CourseName"].ToString();
                Course course = new Course(courseId, courseName);
                courses.Add(course);
            }

            return courses;
        }
    }
}
