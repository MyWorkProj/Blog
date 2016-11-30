using Blog.Common.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.IServices
{
    public interface ILogger
    {
        void Log(LogType type, string message);
        void LogException(Exception e);
    }
}
