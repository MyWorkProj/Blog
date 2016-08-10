/**  版本信息模板在安装目录下，可自行修改。
* countnumtb.cs
*
* 功 能： N/A
* 类 名： countnumtb
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/27 15:40:19   N/A    初版
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
using Maticsoft.DBUtility;//Please add references
namespace BlogSpace.DAL.Blog
{
	/// <summary>
	/// 数据访问类:countnumtb
	/// </summary>
	public partial class countnumtb
	{
		public countnumtb()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("Id", "countnumtb"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from countnumtb");
			strSql.Append(" where Id=@Id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int32)
			};
			parameters[0].Value = Id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BlogSpace.Model.Blog.countnumtb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into countnumtb(");
			strSql.Append("Key,Value,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Key,@Value,@Remark)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Key", MySqlDbType.VarChar,30),
					new MySqlParameter("@Value", MySqlDbType.VarChar,14),
					new MySqlParameter("@Remark", MySqlDbType.VarChar,30)};
			parameters[0].Value = model.Key;
			parameters[1].Value = model.Value;
			parameters[2].Value = model.Remark;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(BlogSpace.Model.Blog.countnumtb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update countnumtb set ");
			strSql.Append("Key=@Key,");
			strSql.Append("Value=@Value,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Id=@Id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Key", MySqlDbType.VarChar,30),
					new MySqlParameter("@Value", MySqlDbType.VarChar,14),
					new MySqlParameter("@Remark", MySqlDbType.VarChar,30),
					new MySqlParameter("@Id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.Key;
			parameters[1].Value = model.Value;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.Id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from countnumtb ");
			strSql.Append(" where Id=@Id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int32)
			};
			parameters[0].Value = Id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from countnumtb ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public BlogSpace.Model.Blog.countnumtb GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Key,Value,Remark from countnumtb ");
			strSql.Append(" where Id=@Id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int32)
			};
			parameters[0].Value = Id;

			BlogSpace.Model.Blog.countnumtb model=new BlogSpace.Model.Blog.countnumtb();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public BlogSpace.Model.Blog.countnumtb DataRowToModel(DataRow row)
		{
			BlogSpace.Model.Blog.countnumtb model=new BlogSpace.Model.Blog.countnumtb();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Key"]!=null)
				{
					model.Key=row["Key"].ToString();
				}
				if(row["Value"]!=null)
				{
					model.Value=row["Value"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Key,Value,Remark ");
			strSql.Append(" FROM countnumtb ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM countnumtb ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from countnumtb T ");
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
			parameters[0].Value = "countnumtb";
			parameters[1].Value = "Id";
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

