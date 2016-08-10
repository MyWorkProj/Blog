using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace Blog.Common
{
    public class LogAttribute : ActionFilterAttribute
    {
        private string _msg = string.Empty;
        private string _token = string.Empty;
        private string _remark = string.Empty;
        public LogAttribute() { }

        public LogAttribute(string msg)
        {
            this._msg = msg;
        }

        //http://www.cnblogs.com/shan333chao/p/5002054.html
        private static readonly string key = "enterTime";
        private const string UserToken = "token";
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Method != HttpMethod.Options)
            {
                // 标记log
                var logAction = actionContext.ActionDescriptor.GetCustomAttributes<NoLogAttribute>();
                if (!logAction.Any())
                {
                    actionContext.Request.Properties[key] = DateTime.Now.ToBinary();
                    this._token = GetToken(actionContext, out this._remark);
                }
            }
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Method != HttpMethod.Options)
            {
                object beginTime = null;
                if (actionExecutedContext.Request.Properties.TryGetValue(key, out beginTime))
                {
                    DateTime time = DateTime.FromBinary(Convert.ToInt64(beginTime));
                    var request = HttpContext.Current.Request;
                    var logDetail = new LogDetail
                    {
                        //获取action名称
                        ActionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                        //获取Controller 名称
                        ControllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                        //获取action开始执行的时间
                        EnterTime = time,
                        //获取执行action的耗时
                        CostTime = (DateTime.Now - time).TotalMilliseconds,
                        Navigator = request.UserAgent,
                        Token = this._token,
                        //获取用户ID
                        UId = UserTokenManager.GetUId(this._token),
                        //获取访问的ip
                        IP = request.UserHostAddress,
                        UserHostName = request.UserHostName,
                        UrlReferrer = request.UrlReferrer != null ? request.UrlReferrer.AbsoluteUri : "",
                        Browser = request.Browser.Browser + " - " + request.Browser.Version + " - " + request.Browser.Type,
                        //获取request提交的参数
                        Paramaters = GetRequestValues(actionExecutedContext),
                        //获取response响应的结果
                        ExecuteResult = GetResponseValues(actionExecutedContext),
                        AttrTitle = this._msg,
                        Remark = this._remark,
                        RequestUri = request.Url.AbsoluteUri
                    };

                    // 登录log
                    var logRep = ContainerManager.Resolve<ISysLogRepository>();
                    var log = new Log()
                    {
                        Action = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                        CreateDate = DateTime.Now,
                        CreatorLoginName = RISContext.Current.CurrentUserInfo.UserName,
                        IpAddress = request.UserHostAddress,
                        Detail = Utility.JsonSerialize<LogDetail>(logDetail)
                    };

                    logRep.Add(log);
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }

        private string GetToken(System.Web.Http.Controllers.HttpActionContext actionContext, out string msg)
        {
            Dictionary<string, object> actionArguments = actionContext.ActionArguments;
            HttpMethod type = actionContext.Request.Method;
            msg = "";
            var token = "";
            if (type == HttpMethod.Post)
            {
                if (actionArguments.ContainsKey(UserToken))
                {
                    if (actionArguments[UserToken] != null)
                        token = actionArguments[UserToken].ToString();
                }
                else
                {
                    foreach (var value in actionArguments.Values)
                    {
                        if (value != null && value.GetType().GetProperty(UserToken) != null)
                            token = value.GetType().GetProperty(UserToken).GetValue(value, null).ToString();
                    }
                }

                if (string.IsNullOrEmpty(token))
                    msg = "匿名用户";
            }
            else if (type == HttpMethod.Get)
            {
                if (!actionArguments.ContainsKey(UserToken))
                    msg = "匿名用户";
                // throw new HttpException(401, "还未登录");

                if (actionArguments[UserToken] != null)
                    token = actionArguments[UserToken].ToString();
                else
                    msg = "匿名用户";
            }
            else if (type == HttpMethod.Options)
            {

            }
            else
            {
                throw new HttpException(404, "暂未开放除POST，GET之外的访问方式!");
            }
            return token;
        }
        /// <summary>
        /// 读取request 的提交内容
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <returns></returns>
        public string GetRequestValues(HttpActionExecutedContext actionExecutedContext)
        {

            Stream stream = actionExecutedContext.Request.Content.ReadAsStreamAsync().Result;
            Encoding encoding = Encoding.UTF8;
            /*
                这个StreamReader不能关闭，也不能dispose， 关了就傻逼了
                因为你关掉后，后面的管道  或拦截器就没办法读取了
            */
            var reader = new StreamReader(stream, encoding);
            string result = reader.ReadToEnd();
            /*
            这里也要注意：   stream.Position = 0;
            当你读取完之后必须把stream的位置设为开始
            因为request和response读取完以后Position到最后一个位置，交给下一个方法处理的时候就会读不到内容了。
            */
            stream.Position = 0;
            return result;
        }

        /// <summary>
        /// 读取action返回的result
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <returns></returns>
        public string GetResponseValues(HttpActionExecutedContext actionExecutedContext)
        {
            Stream stream = actionExecutedContext.Response.Content.ReadAsStreamAsync().Result;
            Encoding encoding = Encoding.UTF8;
            /*
            这个StreamReader不能关闭，也不能dispose， 关了就傻逼了
            因为你关掉后，后面的管道  或拦截器就没办法读取了
            */
            var reader = new StreamReader(stream, encoding);
            string result = reader.ReadToEnd();
            /*
            这里也要注意：   stream.Position = 0; 
            当你读取完之后必须把stream的位置设为开始
            因为request和response读取完以后Position到最后一个位置，交给下一个方法处理的时候就会读不到内容了。
            */
            stream.Position = 0;
            return result;
        }
    }


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class NoErrorHandlerAttribute : Attribute
    {
    }
}