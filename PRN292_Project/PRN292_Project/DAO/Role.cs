using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PRN292_Project.DAO
{
    class Role
    {
        private int roleId;
        private string roleName;

        public Role()
        {
        }

        public Role(int roleId, string roleName)
        {
            this.RoleId = roleId;
            this.RoleName = roleName;
        }

        public int RoleId { get => roleId; set => roleId = value; }
        public string RoleName { get => roleName; set => roleName = value; }

        internal static List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            DataTable dt = Database.GetDataBySql("select * from Role");
            foreach(DataRow data in dt.Rows)
            {
                int roleId = Convert.ToInt32(data["RoleId"]);
                string roleName = data["RoleName"].ToString();
                Role role = new Role(roleId, roleName);
                roles.Add(role);
            }

            return roles;
        }
    }
}
