using System;
using $ext_safeprojectname$.Common.Interfaces.Services;
using AutofacModularity;
using NLog;

namespace $safeprojectname$
{

    [RegisterService]
	public class LoggingService : ILoggingService
	{

		public static NLog.Logger _logger = LogManager.GetLogger("$safeprojectname$");

		public void SetName(string LoggerName)
		{
			_logger = LogManager.GetLogger(LoggerName);
		}


		public void Log(LogLevel lvl, string Message)
		{
			_logger.Log(lvl, Message);
		}


		public void LogEx(string Message, Exception Ex)
		{
			_logger.ErrorException(Message, Ex);
		}

	}

}