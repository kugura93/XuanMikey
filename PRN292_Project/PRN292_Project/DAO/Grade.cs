using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PRN292_Project.DAO
{
    class Grade
    {
        private string classId;
        private string studentId;
        private string teacherId;
        private int markId;
        private float xGrade;
        private string courseId;

        public Grade()
        {
        }

        public Grade(string classId, string studentId, string teacherId, int markId, float xGrade, string courseId)
        {
            this.ClassId = classId;
            this.StudentId = studentId;
            this.TeacherId = teacherId;
            this.MarkId = markId;
            this.XGrade = xGrade;
            this.CourseId = courseId;
        }

        public string ClassId { get => classId; set => classId = value; }
        public string StudentId { get => studentId; set => studentId = value; }
        public string TeacherId { get => teacherId; set => teacherId = value; }
        public int MarkId { get => markId; set => markId = value; }
        public float XGrade { get => xGrade; set => xGrade = value; }
        public string CourseId { get => courseId; set => courseId = value; }

        internal static List<Grade> GetCourseGrade(string classid, string courseid, string studentid){
            List<Grade> grades = new List<Grade>();
            DataTable dt = Database.GetDataBySql("select * from Grade where " +
                    "ClassId = '" + classid + "' and " +
                    "CourseId = '" + courseid + "' and " +
                    "StudentId = '" + studentid + "'");
            foreach (DataRow data in dt.Rows)
            {
                string classId = data["ClassId"].ToString();
                string studentId = data["StudentId"].ToString();
                string teacherId = data["TeacherId"].ToString();
                int markId = Convert.ToInt32(data["MarkId"]);
                float xGrade = float.Parse(data["Grade"].ToString());
                string courseId = data["CourseId"].ToString();

                Grade grade = new Grade(classId, studentId, teacherId, markId, xGrade, courseId);
                grades.Add(grade);
            }

            return grades;
        }

        internal static List<Grade> GetAllGrade(string studentid)
        {
            List<Grade> grades = new List<Grade>();
            DataTable dt = Database.GetDataBySql("select * from Grade where " +
                    "StudentId = '" + studentid + "' order by CourseId");
            foreach (DataRow data in dt.Rows)
            {
                string classId = data["ClassId"].ToString();
                string studentId = data["StudentId"].ToString();
                string teacherId = data["TeacherId"].ToString();
                int markId = Convert.ToInt32(data["MarkId"]);
                float xGrade = float.Parse(data["Grade"].ToString());
                string courseId = data["CourseId"].ToString();

                Grade grade = new Grade(classId, studentId, teacherId, markId, xGrade, courseId);
                grades.Add(grade);
            }

            return grades;
        }
    }
}
