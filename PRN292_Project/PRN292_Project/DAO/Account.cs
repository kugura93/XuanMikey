using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PRN292_Project.DAO
{
    class Account
    {
        private string userId;
        private string userName;
        private string passWord;
        private int roleId;

        public Account()
        {
        }

        public Account(string userId, string userName, string passWord, int roleId)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.PassWord = passWord;
            this.RoleId = roleId;
        }

        public string UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int RoleId { get => roleId; set => roleId = value; }

        internal static List<Account> GetAccount(string username, string password, int role)
        {
            
            List<Account> accounts = new List<Account>();
            DataTable dt = Database.GetDataBySql("select * from Account where Username = '" + username + "' and Password = '" + password + "' and RoleId = " + role.ToString());
            foreach (DataRow data in dt.Rows)
            {
                string userId = data["UserId"].ToString();
                string userName = data["UserName"].ToString();
                string passWord = data["PassWord"].ToString();
                int roleId = Convert.ToInt32(data["RoleId"]);
                Account account = new Account(userId, userName, passWord, roleId);
                accounts.Add(account);
            }

            return accounts;
        }

        internal static int UpdatePassword(string userId, string passWord)
        {
            string sql = "update Account set Password = @passWord where UserId = @userId";
            SqlParameter param1 = new SqlParameter("@passWord", SqlDbType.NVarChar);
            param1.Value = passWord;
            SqlParameter param2 = new SqlParameter("@userId", SqlDbType.NVarChar);
            param2.Value = userId;

            return Database.ExecuteSql(sql, param1, param2);
        }
    }
}
