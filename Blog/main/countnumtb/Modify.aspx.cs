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
namespace BlogSpace.Web.Blog.countnumtb
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
		BlogSpace.BLL.Blog.countnumtb bll=new BlogSpace.BLL.Blog.countnumtb();
		BlogSpace.Model.Blog.countnumtb model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtKey.Text=model.Key;
		this.txtValue.Text=model.Value;
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtKey.Text.Trim().Length==0)
			{
				strErr+="Key不能为空！\\n";	
			}
			if(this.txtValue.Text.Trim().Length==0)
			{
				strErr+="Value不能为空！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="Remark不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string Key=this.txtKey.Text;
			string Value=this.txtValue.Text;
			string Remark=this.txtRemark.Text;


			BlogSpace.Model.Blog.countnumtb model=new BlogSpace.Model.Blog.countnumtb();
			model.Id=Id;
			model.Key=Key;
			model.Value=Value;
			model.Remark=Remark;

			BlogSpace.BLL.Blog.countnumtb bll=new BlogSpace.BLL.Blog.countnumtb();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
