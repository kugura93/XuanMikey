using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PRN292_Project.DAO
{
    static class Database
    {
        internal static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["PROJECT"].ToString());
        }

        //select : trich xuat du lieu -> Disconnected
        internal static DataTable GetDataBySql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        //Insert, Update, Delete -> Connected
        internal static int ExecuteSql(string sql, params SqlParameter[] sqlParameters)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Parameters.AddRange(sqlParameters);
            cmd.Connection.Open();
            int numRows = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return numRows;
        }

        internal static string GetUserId(string username, string password, int roleid)
        {
            string userId = "";

            string sql = "select UserId from Account where Username = '" + username + "' and Password = '" + password + "' and RoleId = " + roleid.ToString();
            DataTable dt = GetDataBySql(sql);
            if (dt.Rows.Count == 0)
            {
                userId = "";
            }
            else
                userId = dt.Rows[0]["UserId"].ToString();

            return userId;
        }

        internal static string GetUserIdByStudentId(string id)
        {
            string userId = "";

            string sql = "select UserId from Student where StudentId = '" + id + "'";
            DataTable dt = GetDataBySql(sql);
            if(dt.Rows.Count == 0)
            {
                userId = "";
            }
            else
            {
                userId = dt.Rows[0]["UserId"].ToString();
            }

            return userId;
        }

        internal static string GetStudentId(string userId)
        {
            string studentId = "";

            string sql = "select StudentId from Student where UserId = '" + userId + "'";
            DataTable dt = GetDataBySql(sql);
            if(dt.Rows.Count == 0)
            {
                studentId = "";
            }
            else
            {
                studentId = dt.Rows[0]["StudentId"].ToString();
            }

            return studentId;
        }

        internal static string GetUsername(string userId)
        {
            string userName = "";

            string sql = "select Username from Account where UserId = '" + userId + "'";
            DataTable dt = GetDataBySql(sql);
            if (dt.Rows.Count == 0)
            {
                userName = "";
            }
            else
            {
                userName = dt.Rows[0]["Username"].ToString();
            }

            return userName;
        }
    }
}
