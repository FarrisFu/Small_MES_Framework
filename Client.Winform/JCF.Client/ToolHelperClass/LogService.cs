using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ToolHelperClass
{
    /// <summary>
    /// 单例日志服务类Log4net
    /// </summary>
    public class LogService
    {
        private static readonly ILog Logger;

        static LogService()
        {
            System.IO.FileInfo fileinfo = new System.IO.FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}/Config/log4net.config");
            log4net.Config.XmlConfigurator.Configure(fileinfo);
            Logger = LogManager.GetLogger(typeof(LogService));
        }

        public static void Info(object message)
        {
            Logger.Info(message);
        }

        public static void Info(object message, Exception ex)
        {
            Logger.Info(message, ex);
        }

        public static void Debug(object message)
        {
            Logger.Debug(message);
        }

        public static void Debug(object message, Exception ex)
        {
            Logger.Debug(message, ex);
        }

        public static void Error(object message)
        {
            Logger.Error(message);
        }

        public static void Error(object message, Exception ex)
        {
            Logger.Error(message, ex);
        }      

        public static void Warn(object message)
        {
            Logger.Warn(message);
        }

        public static void Warn(object message, Exception ex)
        {
            Logger.Warn(message, ex);
        }       
    }
}
