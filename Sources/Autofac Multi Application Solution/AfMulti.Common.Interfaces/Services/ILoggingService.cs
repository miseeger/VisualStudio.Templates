using System;
using NLog;

namespace $safeprojectname$.Services
{

	public interface ILoggingService
	{
		void SetName(string LoggerName);
		void Log(LogLevel lvl, string Message);
		void LogEx(string Message, Exception Ex);
	}

}
