using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace DAL
{
    public class DBHelper
    {
        //数据库连接字符串
        static string strconn = "Data Source=.;Initial Catalog=Day13DB;Integrated Security=True";

        //执行sql语句查询

        /// <summary>
        /// 获取DateTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        static public DataTable GetDataTable(string sql)
        {
            using (SqlConnection conn=new SqlConnection(strconn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter apd = new SqlDataAdapter(sql, conn);
                apd.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// 获取List集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        static public List<T> GetList<T>(string sql)
        {
            var dt = GetDataTable(sql);
            var strlist = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<List<T>>(strlist);
            return list;
        }

        //执行存储过程查询

        /// <summary>
        /// 获取DateTable
        /// </summary>
        /// <param name="pname">存储过程名称</param>
        /// <param name="paras">存储过程参数</param>
        /// <returns></returns>
        static public DataTable GetDataTableProc(string pname, SqlParameter[] paras = null)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(pname, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                SqlDataAdapter apd = new SqlDataAdapter(cmd);
                apd.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// 获取List集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="pname">存储过程名称</param>
        /// <param name="paras">存储过程参数</param>
        /// <returns></returns>
        static public List<T> GetListProc<T>(string pname, SqlParameter[] paras = null)
        {
            var dt = GetDataTableProc(pname, paras);
            var strlist = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<List<T>>(strlist);
            return list;
        }

        /// <summary>
        /// 执行sql语句增删改
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        static public int ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行存储过程增删改
        /// </summary>
        /// <param name="pname">存储过程名称</param>
        /// <param name="paras">存储过程参数</param>
        /// <returns></returns>
        static public int ExecuteNonQueryProc(string pname,SqlParameter[] paras=null)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(pname, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (paras!=null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
