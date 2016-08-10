/**  版本信息模板在安装目录下，可自行修改。
* userinfotb.cs
*
* 功 能： N/A
* 类 名： userinfotb
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/31 14:14:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;
using Microsoft;
using System.Data.SqlClient;//Please add references

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:userinfotb
    /// </summary>
    public partial class userinfotb
    {
        public userinfotb()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return Maticsoft.DBUtility.DbHelperMySQL.GetMaxID("id", "userinfotb");
        }
        public DataSet GetAll()
        {
            DataSet ds = new DataSet();
            string connectionString = PubConstant.GetDyConnectionString();
            SqlConnection conn = new SqlConnection(connectionString);
            
            SqlParameter[] parm = {
					new SqlParameter("@id", SqlDbType.Int)
			};
            ds = Microsoft.SqlHelper.ExecuteDataset(connectionString,CommandType.StoredProcedure,"",parm);

            return ds;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from userinfotb");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.userinfotb model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into userinfotb(");
            strSql.Append("name,age,phone,adress)");
            strSql.Append(" values (");
            strSql.Append("@name,@age,@phone,@adress)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,30),
					new MySqlParameter("@age", MySqlDbType.Int32,11),
					new MySqlParameter("@phone", MySqlDbType.VarChar,30),
					new MySqlParameter("@adress", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.age;
            parameters[2].Value = model.phone;
            parameters[3].Value = model.adress;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.userinfotb model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update userinfotb set ");
            strSql.Append("name=@name,");
            strSql.Append("age=@age,");
            strSql.Append("phone=@phone,");
            strSql.Append("adress=@adress");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,30),
					new MySqlParameter("@age", MySqlDbType.Int32,11),
					new MySqlParameter("@phone", MySqlDbType.VarChar,30),
					new MySqlParameter("@adress", MySqlDbType.VarChar,50),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.age;
            parameters[2].Value = model.phone;
            parameters[3].Value = model.adress;
            parameters[4].Value = model.id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from userinfotb ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from userinfotb ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.userinfotb GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,age,phone,adress from userinfotb ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            Maticsoft.Model.userinfotb model = new Maticsoft.Model.userinfotb();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.userinfotb DataRowToModel(DataRow row)
        {
            Maticsoft.Model.userinfotb model = new Maticsoft.Model.userinfotb();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["age"] != null && row["age"].ToString() != "")
                {
                    model.age = int.Parse(row["age"].ToString());
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["adress"] != null)
                {
                    model.adress = row["adress"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,age,phone,adress ");
            strSql.Append(" FROM userinfotb ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM userinfotb ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from userinfotb T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "userinfotb";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

