using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Blog.Common
{
    /// <summary>
    /// WebApiConfig
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// WebApiConfig Register
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            //config.Filters.Add(new TokenAuthorizeAttribute());
            config.MessageHandlers.Add(new CrosHandler());
            config.Filters.Add(new ApiAuthorizeAttribute());
            config.Filters.Add(new ErrorHandleAttribute("错误处理"));
            // Web API 路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "mobileapi/{controller}/{action}/{id}",
                defaults: new { controller = "Test", action = "GetTestValue", id = RouteParameter.Optional }
            );
        }
    }
}