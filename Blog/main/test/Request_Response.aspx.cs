using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.main.test
{
    public partial class Request_Response : System.Web.UI.Page
    {
        //创建计时器
        private readonly Stopwatch Watch = new Stopwatch();
        protected void Page_Load(object sender, EventArgs e)
        {
            Watch.Start();

            string  path = MapPath("ccc");

            if (!Page.IsPostBack)
            {
                Response.Write("第一次提交!");
                Server.Transfer("t2.html", true);
            }
            else
            {
                Response.Write("==========postback  t2====="); 
                Response.Redirect("t2.html", true);
            }

            Watch.Stop();
            long  times = Watch.ElapsedMilliseconds;


        }
    }
}