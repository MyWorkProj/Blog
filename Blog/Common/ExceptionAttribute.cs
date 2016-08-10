using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Blog.Common
{
    public class ErrorHandleAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        private string _msg = string.Empty;

        public ErrorHandleAttribute() { }

        public ErrorHandleAttribute(string msg)
        {
            this._msg = msg;
        }
        public override void OnException(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            // 取得发生异常时的错误讯息
            //var errorMessage = actionExecutedContext.Exception.Message;
            // 标记log
            var logAction = actionExecutedContext.ActionContext.ActionDescriptor.GetCustomAttributes<NoErrorHandlerAttribute>();
            if (logAction.Any())
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new ResultData(ResultType.SystemException, actionExecutedContext.Exception.Message));
                return;
            }

            var request = HttpContext.Current.Request;
            var logDetail = new LogDetail
            {
                //获取action名称
                ActionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                //获取Controller 名称
                ControllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Navigator = request.UserAgent,
                //获取访问的ip
                IP = request.UserHostAddress,
                UserHostName = request.UserHostName,
                UrlReferrer = request.UrlReferrer != null ? request.UrlReferrer.AbsoluteUri : "",
                Browser = request.Browser.Browser + " - " + request.Browser.Version + " - " + request.Browser.Type,
                //获取request提交的参数
                Paramaters = GetRequestValues(actionExecutedContext),
                //获取response响应的结果
                //ExecuteResult = GetResponseValues(actionExecutedContext),  //这句会报错，异常没有处理结果
                AttrTitle = this._msg,
                ErrorMsg = string.Format("错误信息：{0}， 异常跟踪：{1}", actionExecutedContext.Exception.Message, actionExecutedContext.Exception.StackTrace),
                RequestUri = request.Url.AbsoluteUri
            };

            // 写log
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
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, new ResultData(ResultType.SystemException, actionExecutedContext.Exception.Message));
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
    }
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class NoErrorHandlerAttribute : Attribute
    {
    }

}