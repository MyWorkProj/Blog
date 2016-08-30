using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Drawing;
using LTP.Accounts.Bus;
using System.Text.RegularExpressions;
using System.Web.Services;
using Blog.Common;
using Blog.IServices;
using Blog.Common.EnumType;
using Blog.Services;
using System.Reflection;

namespace angularJSProj.blog.main.bloginfotb
{
    public partial class List : System.Web.UI.Page
    {
        BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        protected void Page_Load(object sender, EventArgs e)
        {
            // 写日志
            loginfo.Info("========1=============");

            //LOG.Log(LogType.Message, "当前时间:" + System.DateTime.Now + "======测试2==============");
            //if (!Page.IsPostBack)
            //{
            //    gridView.BorderColor = ColorTranslator.FromHtml("Blue");
            //    gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml("Gray");
            //    btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
            //    BindData();
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            bll.DeleteList(idlist);
            BindData();
        }

        [WebMethod]
        public static int GetAllCount()
        {
            BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();
            DataSet ds = bll.GetAllList();
            return ds.Tables[0].Rows.Count;
        }
        [WebMethod]
        public static List<BlogSpace.Model.Blog.bloginfotb> GetListByPage(string strWhere, string orderby, int startIndex, int length)
        {
            BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();

            List<BlogSpace.Model.Blog.bloginfotb> list = new List<BlogSpace.Model.Blog.bloginfotb>();
            DataSet ds = bll.GetListByPage(strWhere, orderby, startIndex, length);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                BlogSpace.Model.Blog.bloginfotb model = new BlogSpace.Model.Blog.bloginfotb();
                model.Content = StringHelper.NoHTML(ds.Tables[0].Rows[i]["Content"].ToString());
                model.CreateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreateDate"]);
                model.Mark = ds.Tables[0].Rows[i]["Mark"].ToString();
                model.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                model.TypeNo = ds.Tables[0].Rows[i]["TypeNo"].ToString();
                model.Id = Convert.ToInt32( ds.Tables[0].Rows[i]["ID"]);
                model.CDate = ds.Tables[0].Rows[i]["CreateDate"].ToString();
                list.Add(model);
            }

            return list;
        }
        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere.AppendFormat("content like '%{0}%'", txtKeyword.Text.Trim());
            }

            pageSplit(strWhere.ToString(),0,10);
        }

        public void pageSplit(string strWhere,int startindex,int length) 
        {
            DataSet ds = new DataSet();
            ds = bll.GetListByPage(strWhere.ToString(), "Content",startindex,length);
            //ds = bll.GetList(strWhere.ToString());

            DataTable tb = ds.Tables[0];
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string txtOriContent = tb.Rows[i]["Content"].ToString();
                string finalContent =StringHelper.NoHTML(txtOriContent);


                tb.Rows[i]["Content"] = getMinContent(finalContent);
            }

            //ds.Reset();
            //ds.Tables.Add(tb);

            gridView.DataSource = ds;
            gridView.DataBind();
        }
        /// <summary>
        /// 获取字符串前50个字符
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string getMinContent(string content){
            if (content.Length > 100)
            {
                content = content.Substring(0, 100) + "......";
            }
            return content;
        }

        
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Text = "<input id='Checkbox2' type='checkbox' onclick='CheckAll()'/><label></label>";
            }
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗\")");

                //object obj1 = DataBinder.Eval(e.Row.DataItem, "Levels");
                //if ((obj1 != null) && ((obj1.ToString() != "")))
                //{
                //    e.Row.Cells[1].Text = obj1.ToString();
                //}

            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //#warning 代码生成警告：请检查确认真实主键的名称和类型是否正确
            //int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            //bll.Delete(ID);
            //gridView.OnBind();
        }

        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl("DeleteThis");
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    //#warning 代码生成警告：请检查确认Cells的列索引是否正确
                    if (gridView.DataKeys[i].Value != null)
                    {
                        idlist += gridView.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }

        #endregion


    }
}