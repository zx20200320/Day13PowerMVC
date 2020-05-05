using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 列表显示
        /// </summary>
        /// <returns></returns>
        public List<UserRole> ShowUserRole()
        {
            string sql = @"select u.UId,UName,RName from UserInfo u 
                            left join UserRole t on u.UId=t.UId
                            left join RoleInfo r on r.RId=t.RId";
            return DBHelper.GetList<UserRole>(sql);
        }

        /// <summary>
        /// 所有角色
        /// </summary>
        /// <returns></returns>
        public List<RoleInfo> GetRoleInfos()
        {
            string sql = "select * from RoleInfo";
            return DBHelper.GetList<RoleInfo>(sql);
        }

        /// <summary>
        /// 通过用户Id获取
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public List<UserRole> GetUserRolesById(int UId)
        {
            string sql = "select r.RId,RName from UserRole t join RoleInfo r on r.RId=t.RId where UId=" + UId;
            return DBHelper.GetList<UserRole>(sql);
        }

        /// <summary>
        /// 分配角色权限
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public int AddUserRole(UserRole mod)
        {
            string sql = $"insert into UserRole values({mod.UId},{mod.RId})";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 取消角色权限
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="rId"></param>
        /// <returns></returns>
        public int DelUserRole(int uId,int rId)
        {
            string sql = $"delete from UserRole where UId={uId} and RId={rId}";
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
