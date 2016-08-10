using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace angularJSProj.blog.main.bloginfotb
{
    public partial class Modify : System.Web.UI.Page
    {
        public string GetContent = "";
        public int Id ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                   Id = (Convert.ToInt32(Request.Params["id"]));

                    BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();
                    BlogSpace.Model.Blog.bloginfotb model = bll.GetModel(Id);
                    if (model != null) {
                        this.ModelId.Value = Id.ToString();
                        this.txtMark.Text = model.Mark;
                        this.txtTitle.Text = model.Title;
                        this.txtContent2.Value = model.Content;
                        this.txtTypeNo.Text = model.TypeNo;

                        GetContent = model.Content;    
                    }
                }
            }
        }


        public void btnSave_Click(object sender, EventArgs e)
        {

            int Id = int.Parse(this.ModelId.Value);
            string Mark = this.txtMark.Text;
            string Title = this.txtTitle.Text;
            string Content = this.txtContent2.Value;
            string TypeNo = this.txtTypeNo.Text;
            //DateTime CreateDate = DateTime.Parse(this.txtCreateDate.Text);


            BlogSpace.Model.Blog.bloginfotb model = new BlogSpace.Model.Blog.bloginfotb();
            model.Id = Id;
            model.Mark = Mark;
            model.Title = Title;
            model.Content = Content;
            model.TypeNo = TypeNo;
            //model.CreateDate = CreateDate;

            BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();
            bll.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}