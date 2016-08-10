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
namespace Maticsoft.Model
{
	/// <summary>
	/// userinfotb:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class userinfotb
	{
		public userinfotb()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _age;
		private string _phone;
		private string _adress;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adress
		{
			set{ _adress=value;}
			get{return _adress;}
		}
		#endregion Model

	}
}

