using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PRN292_Project.DAO
{
    class Student
    {
        private string studentId;
        private string studentName;
        private string studentEmail;
        private string address;
        private string fax;
        private bool gender;
        private string usderId;

        public Student()
        {
        }

        public Student(string studentId, string studentName, string studentEmail, string address, string fax, bool gender, string usderId)
        {
            this.studentId = studentId;
            this.studentName = studentName;
            this.studentEmail = studentEmail;
            this.address = address;
            this.fax = fax;
            this.gender = gender;
            this.usderId = usderId;
        }

        public string StudentId { get => studentId; set => studentId = value; }
        public string StudentName { get => studentName; set => studentName = value; }
        public string StudentEmail { get => studentEmail; set => studentEmail = value; }
        public string Address { get => address; set => address = value; }
        public string Fax { get => fax; set => fax = value; }
        public bool Gender { get => gender; set => gender = value; }
        public string UsderId { get => usderId; set => usderId = value; }

        internal static int UpdateStudent(ArrayList list)
        {
            string sql = "update Student set StudentName = @studentName, Fax = @fax, Gender = @gender, Address = @address, " +
                "StudentEmail = @studentEmail";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@studentName", SqlDbType.NVarChar),
                new SqlParameter("@fax", SqlDbType.NVarChar),
                new SqlParameter("@gender", SqlDbType.Bit),
                new SqlParameter("@address", SqlDbType.NVarChar),
                new SqlParameter("@studentEmail", SqlDbType.NVarChar)
            };

            for(int i = 0; i < list.Count; i++)
            {
                parameters[i].Value = list[i];
            }

            return Database.ExecuteSql(sql, parameters);
        }
    }
}
