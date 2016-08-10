using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace angularJSProj.blog.main.bloginfotb
{
    public partial class show : System.Web.UI.Page
    {
        public string GetContent = "";
        public int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    Id = (Convert.ToInt32(Request.Params["id"]));

                    BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();
                    BlogSpace.Model.Blog.bloginfotb model = bll.GetModel(Id);
                    if (model != null)
                    {
                        this.txtMark.Text = model.Mark;
                        this.txtTitle.Text = model.Title;
                        //this.txtContent2.Value = model.Content;
                        this.txtTypeNo.Text = model.TypeNo;

                        GetContent = model.Content;
                    }
                }
            }
        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}