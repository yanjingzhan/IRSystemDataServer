using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IRSystemDataServer.Helpers
{
    public class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public LogHelper()
        {
            SetConfig();
        }

        public void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public void Log(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public void LogError(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            }
        }
    }
}