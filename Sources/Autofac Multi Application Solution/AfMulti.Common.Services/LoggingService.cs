using System;
using $ext_safeprojectname$.Common.Interfaces.Services;
using AutofacModularity;
using NLog;

namespace $safeprojectname$
{

    [RegisterService]
	public class LoggingService : ILoggingService
	{
		private static NLog.Logger _logger = LogManager.GetLogger("$safeprojectname$");

		
		public void SetName(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }


        public void Log(LogLevel lvl, string message)
        {
            _logger.Log(lvl, message);
        }


        public void LogEx(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }

	}

}