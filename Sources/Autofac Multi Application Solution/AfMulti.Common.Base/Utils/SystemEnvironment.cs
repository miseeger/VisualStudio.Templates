using System;

namespace $safeprojectname$.Utils
{

	public static class SystemEnvironment
	{

		public static string CurrentUser
		{
			get { return Environment.UserName; }
			set { }
		}


		public static string CurrentDomain
		{
			get { return Environment.UserDomainName; }
			set { }
		}


		public static string CurrentMachine
		{
			get { return Environment.MachineName; }
			set { }
		}


		public static OperatingSystem CurrentOSVersion
		{
			get { return Environment.OSVersion; }
			set { }
		}

	}

}