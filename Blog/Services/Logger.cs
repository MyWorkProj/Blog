using Blog.Common.EnumType;
using Blog.IServices;
using log4net;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Services
{
    public class Logger:ILogger
    {
        private readonly IHubContext _logContext;
        private readonly ILog _log4net;
        public void Log(Common.EnumType.LogType type, string message)
        {
            Task.Run(async () =>
            {
                var formatted = String.Format("[{0}]: {1}", DateTime.UtcNow, message);

                try
                {
                    switch (type)
                    {
                        case LogType.Message:
                            _log4net.Info(formatted);
                            await _logContext.Clients.All.logMessage(formatted);
                            break;
                        case LogType.Error:
                            _log4net.Error(formatted);
                            await _logContext.Clients.All.logError(formatted);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Error occurred while logging: " + ex);
                    _log4net.Error(formatted);
                }
            });
        }

        public void LogException(Exception e)
        {
            _log4net.Error(e.Message);
            _log4net.Error(e.StackTrace);
        }
    }
}