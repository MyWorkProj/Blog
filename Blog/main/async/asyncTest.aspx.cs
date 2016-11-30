using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.main.async
{
    public partial class asyncTest : System.Web.UI.Page
    {
        //public static string showValue { get; set; }
        public string showValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            showValue = "==1====";
        }

        async Task DoSomethingAsync()
        {
            int val = 13;
            // 异步方式等待1 秒
            await Task.Delay(TimeSpan.FromSeconds(1));
            val *= 2;
            // 异步方式等待1 秒
            await Task.Delay(TimeSpan.FromSeconds(1));
            //Trace.WriteLine(val);
            showValue = val.ToString();

        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            DoSomethingAsync();
        }
        protected void btnClick0_Click(object sender, EventArgs e) {
            showValue = "点击事件触发";
        }
    }
}