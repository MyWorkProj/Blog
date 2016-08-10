using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace BlogSpace.Web.Blog.blogtypenotb
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Id);
				}
			}
		}
			
	private void ShowInfo(int Id)
	{
		BlogSpace.BLL.Blog.blogtypenotb bll=new BlogSpace.BLL.Blog.blogtypenotb();
		BlogSpace.Model.Blog.blogtypenotb model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtType.Text=model.Type;
		this.txtTypeNo.Text=model.TypeNo;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtType.Text.Trim().Length==0)
			{
				strErr+="Type不能为空！\\n";	
			}
			if(this.txtTypeNo.Text.Trim().Length==0)
			{
				strErr+="TypeNo不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string Type=this.txtType.Text;
			string TypeNo=this.txtTypeNo.Text;


			BlogSpace.Model.Blog.blogtypenotb model=new BlogSpace.Model.Blog.blogtypenotb();
			model.Id=Id;
			model.Type=Type;
			model.TypeNo=TypeNo;

			BlogSpace.BLL.Blog.blogtypenotb bll=new BlogSpace.BLL.Blog.blogtypenotb();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
