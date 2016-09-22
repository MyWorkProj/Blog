using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Services;

namespace Blog.main
{
    
    /// <summary>
    /// AjaxWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class AjaxWebService : System.Web.Services.WebService
    {
        BlogSpace.BLL.Blog.blogtypenotb typeBll = new BlogSpace.BLL.Blog.blogtypenotb();
        BlogSpace.BLL.Blog.bloginfotb infoBll = new BlogSpace.BLL.Blog.bloginfotb();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int GetAllCount()
        {
            DataSet ds = infoBll.GetAllList();
            return ds.Tables[0].Rows.Count;
        }

        [WebMethod]
        public List<BlogSpace.Model.Blog.bloginfotb> GetListStrWhere(string strWhere)
        {
            List<BlogSpace.Model.Blog.bloginfotb> list = new List<BlogSpace.Model.Blog.bloginfotb>();
            DataSet ds = infoBll.GetList(strWhere);
            list = infoBll.DataTableToList(ds.Tables[0]);
            return list;
        }

        [WebMethod]
        public List<BlogSpace.Model.Blog.bloginfotb> GetListByPage(string strWhere, string orderby, int startIndex, int length)
        {
            List<BlogSpace.Model.Blog.bloginfotb> list = new List<BlogSpace.Model.Blog.bloginfotb>();
            DataSet ds = infoBll.GetListByPage(strWhere, orderby, startIndex, length);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    BlogSpace.Model.Blog.bloginfotb model = new BlogSpace.Model.Blog.bloginfotb();
            //    model.Content = ds.Tables[0].Rows[i]["Content"].ToString();
            //    model.CreateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreateDate"]);
            //    model.Mark = ds.Tables[0].Rows[i]["Mark"].ToString();
            //    model.Title = ds.Tables[0].Rows[i]["Title"].ToString();
            //    model.TypeNo = ds.Tables[0].Rows[i]["TypeNo"].ToString();

            //    list.Add(model);
            //}
            list = infoBll.DataTableToList(ds.Tables[0]);
            return list;
        }

        [WebMethod]
        //public List<BlogSpace.Model.Blog.blogtypenotb> GetBlogType()
        public string GetBlogType()
        {
            //BlogSpace.BLL.Blog.blogtypenotb bll = new BlogSpace.BLL.Blog.blogtypenotb();
            //DataSet ds = bll.GetList("");

            //List<BlogSpace.Model.Blog.blogtypenotb> list = bll.DataTableToList(ds.Tables[0]);

            //var icount = (from aa in list
            //              select aa).Count();
            //var mytwlist = (from aa in list
            //                orderby aa.Id descending
            //                select aa).Take(10).ToList();

            //List<BlogSpace.Model.Blog.blogtypenotb> list2 = bll.DataTableToList(ds.Tables[0]);
            //foreach (var item in mytwlist)
            //{
            //    BlogSpace.Model.Blog.blogtypenotb model = new BlogSpace.Model.Blog.blogtypenotb();
            //    model.Id = item.Id;
            //    model.ParentId = item.ParentId;
            //    model.Type = item.Type;
            //    model.TypeNo = item.TypeNo;

            //    list2.Add(model);
            //}
            //return list2;


            
            DataSet ds = typeBll.GetList("");

            List<BlogSpace.Model.Blog.blogtypenotb> list = typeBll.DataTableToList(ds.Tables[0]);
            //return list;
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }


        [WebMethod]
        public string GetStatisticData() 
        {
            List<BlogSpace.Model.Blog.bloginfotb> list1 = infoBll.GetModelList(" 1=1 group by mark ");

            List<BlogSpace.Model.Blog.bloginfotb> list = infoBll.GetModelList("");
            foreach (var item in list)
            {
                item.month = GetMonth((DateTime)item.CreateDate);
            }
            StatisticDataModel model = new StatisticDataModel();

            string[] mark = {"","11","aa","bb"};
            for (int j = 1; j < 4; j++)
			{
                string  markValue = mark[j];
                int[] array = new int[13];
			    for (int i = 1; i <= 12; i++)
                {
                    var aa = from c in list
                             where c.month == i.ToString() && c.Mark == markValue
                             select c;
                    array[i] = aa.Count();
                }
                switch(j){
                    case 1: model.mark1 = array;
                        break;
                    case 2: model.mark2 = array;
                        break;
                    case 3: model.mark3 = array;
                        break;
                    default:model.mark4 = array;
                        break;
                }
                
			}
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        public string GetMonth(DateTime dt)
        {
            string month = dt.Month.ToString();
            return month;
        }
    }
    public class StatisticDataModel
    {
        public Array mark1 { get; set; }
        public Array mark2 { get; set; }
        public Array mark3 { get; set; }
        public Array mark4 { get; set; }
    }
}
