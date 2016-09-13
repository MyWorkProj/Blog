using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
namespace Blog.main.test
{
    public partial class classLib : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClassLibrary.log();
            ClassLibrary.log c = new ClassLibrary.log();
            Abss(1,6);
        }

        public static int Abss(int a,int b) { 
            return ClassLibrary.log.Abs(a,b);
        }
    }
}