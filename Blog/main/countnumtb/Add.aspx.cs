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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string Key=this.txtKey.Text;
			string Value=this.txtValue.Text;
			string Remark=this.txtRemark.Text;

			BlogSpace.Model.Blog.countnumtb model=new BlogSpace.Model.Blog.countnumtb();
			model.Key=Key;
			model.Value=Value;
			model.Remark=Remark;

			BlogSpace.BLL.Blog.countnumtb bll=new BlogSpace.BLL.Blog.countnumtb();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
