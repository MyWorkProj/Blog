using System;
using System.Configuration;
using FrameWork.Components;
using FrameWork;
namespace Maticsoft.DBUtility
{
    
    public class PubConstant
    {        
        ///// <summary>
        ///// 获取连接字符串
        ///// </summary>
        //public static string ConnectionString
        //{           
        //    get 
        //    {
        //        string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];       
        //        string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
        //        if (ConStringEncrypt == "true")
        //        {
        //            _connectionString = DESEncrypt.Decrypt(_connectionString);
        //        }
        //        return _connectionString; 
        //    }
        //}

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }

        public static string GetDyConnectionString()
        {
            //get
            //{
                string dbname = DbInfo.dbname;
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    //_connectionString = DESEncrypt.Decrypt(_connectionString);
                    _connectionString = DESEncrypt.DecryptString(_connectionString, "linkcrm!@#123");
                }
                string DBConType = ConfigurationManager.AppSettings["DBConType"];
                if (DBConType.Equals("true"))
                {
                    if (FrameWork.UserData.GetUserDate != null)
                    {
                        int groupid = 0;
                        sys_GroupTable gtinfo = BusinessFacade.sys_GroupDisp(FrameWork.UserData.GetUserDate.U_GroupID);
                        if (gtinfo.G_ParentID != 0)
                        {
                            groupid = gtinfo.G_ParentID;
                        }
                        else
                        {
                            groupid = FrameWork.UserData.GetUserDate.U_GroupID;
                        }
                        FrameWork.Components.sys_GroupTable groupdt = FrameWork.BusinessFacade.sys_GroupDisp(groupid);
                        FrameWork.Components.sys_DbSetTable gt = FrameWork.BusinessFacade.sys_DbSetDisp(groupid);
                        
                        _connectionString = _connectionString.Replace("linkcrm", gt.DbName);
                    }
                    else
                    {
                        throw new Exception("用户登录超时！");
                    }
                }
                return _connectionString;
            //}
        }

        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["MySql"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
    }

    public static class DbInfo
    {
        public static string dbname = "";
    }
}
