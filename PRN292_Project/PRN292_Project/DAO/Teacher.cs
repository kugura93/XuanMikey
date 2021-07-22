using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRN292_Project.DAO
{
    class Teacher
    {
        private string teacherId;
        private string teacherName;
        private string teacherEmail;
        private string address;
        private string fax;
        private bool gendeder;
        private string userId;

        public Teacher()
        {
        }

        public Teacher(string teacherId, string teacherName, string teacherEmail, string address, string fax, bool gendeder, string userId)
        {
            this.TeacherId = teacherId;
            this.TeacherName = teacherName;
            this.TeacherEmail = teacherEmail;
            this.Address = address;
            this.Fax = fax;
            this.Gendeder = gendeder;
            this.UserId = userId;
        }

        public string TeacherId { get => teacherId; set => teacherId = value; }
        public string TeacherName { get => teacherName; set => teacherName = value; }
        public string TeacherEmail { get => teacherEmail; set => teacherEmail = value; }
        public string Address { get => address; set => address = value; }
        public string Fax { get => fax; set => fax = value; }
        public bool Gendeder { get => gendeder; set => gendeder = value; }
        public string UserId { get => userId; set => userId = value; }
    }
}
