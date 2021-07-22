using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PRN292_Project.DAO
{
    class Class
    {
        private string classId;
        private string courseId;
        private string teacherId;
        private string className;
        private string studentId;

        public Class()
        {
        }

        public Class(string classId, string courseId, string teacherId, string className)
        {
            this.ClassId = classId;
            this.CourseId = courseId;
            this.TeacherId = teacherId;
            this.ClassName = className;
        }

        public Class(string classId, string courseId, string teacherId, string className, string studentId)
        {
            this.ClassId = classId;
            this.CourseId = courseId;
            this.TeacherId = teacherId;
            this.ClassName = className;
            this.StudentId = studentId;
        }

        public string ClassId { get => classId; set => classId = value; }
        public string CourseId { get => courseId; set => courseId = value; }
        public string TeacherId { get => teacherId; set => teacherId = value; }
        public string ClassName { get => className; set => className = value; }
        public string StudentId { get => studentId; set => studentId = value; }

        internal static List<Class> GetClassTaken(string id)
        {
            List<Class> classes = new List<Class>();
            DataTable dt = Database.GetDataBySql("select * from Class where StudentId = '" + id + "'");
            foreach(DataRow data in dt.Rows)
            {
                string classId = data["ClassId"].ToString();
                string courseId = data["CourseId"].ToString();
                string teacherId = data["TeacherId"].ToString();
                string className = data["ClassName"].ToString();
                string studentId = data["StudentId"].ToString();
                
                Class @class = new Class(classId, courseId, teacherId, className, studentId);
                classes.Add(@class);
            }

            return classes;
        }

        internal static List<Class> GetClassByCourseId(string courseid)
        {
            List<Class> classes = new List<Class>();
            DataTable dt = Database.GetDataBySql("select * from Class where CourseId like '" + courseid + "%'");
            foreach (DataRow data in dt.Rows)
            {
                string classId = data["ClassId"].ToString();
                string courseId = data["CourseId"].ToString();
                string teacherId = data["TeacherId"].ToString();
                string className = data["ClassName"].ToString();
                string studentId = data["StudentId"].ToString();

                Class @class = new Class(classId, courseId, teacherId, className, studentId);
                classes.Add(@class);
            }

            return classes;
        }

        internal static List<Class> GetClassByClassId(string classid)
        {
            List<Class> classes = new List<Class>();
            DataTable dt = Database.GetDataBySql("select * from Class where ClassId like '" + classid + "%'");
            foreach (DataRow data in dt.Rows)
            {
                string classId = data["ClassId"].ToString();
                string courseId = data["CourseId"].ToString();
                string teacherId = data["TeacherId"].ToString();
                string className = data["ClassName"].ToString();
                string studentId = data["StudentId"].ToString();

                Class @class = new Class(classId, courseId, teacherId, className, studentId);
                classes.Add(@class);
            }

            return classes;
        }

        internal static List<Class> GetClassByTeacherId(string teacherid)
        {
            List<Class> classes = new List<Class>();
            DataTable dt = Database.GetDataBySql("select * from Class where TeacherId like '" + teacherid + "%'");
            foreach (DataRow data in dt.Rows)
            {
                string classId = data["ClassId"].ToString();
                string courseId = data["CourseId"].ToString();
                string teacherId = data["TeacherId"].ToString();
                string className = data["ClassName"].ToString();
                string studentId = data["StudentId"].ToString();

                Class @class = new Class(classId, courseId, teacherId, className, studentId);
                classes.Add(@class);
            }

            return classes;
        }

        internal static List<Class> GetClassByClassName(string studentname)
        {
            List<Class> classes = new List<Class>();
            DataTable dt = Database.GetDataBySql("select * from Class where ClassId like '" + studentname + "%'");
            foreach (DataRow data in dt.Rows)
            {
                string classId = data["ClassId"].ToString();
                string courseId = data["CourseId"].ToString();
                string teacherId = data["TeacherId"].ToString();
                string className = data["ClassName"].ToString();
                string studentId = data["StudentId"].ToString();

                Class @class = new Class(classId, courseId, teacherId, className, studentId);
                classes.Add(@class);
            }

            return classes;
        }
    }
}
