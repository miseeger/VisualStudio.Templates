using System.Net;
using Owin;

namespace $safeprojectname$
{

	/// <summary>
	/// Provides the middleware for Windows authentication.
	/// </summary>
	public static class WinAuthConfig
	{

		// Registers the OWIN middleware. 
		// !!! Important !!! The authentication doesn't use  
		// IntegratedWindowsAuthentication, but NTLM !!!
		public static void Register (ref IAppBuilder app)
		{
			var listener = 
				(HttpListener)app.Properties["System.Net.HttpListener"];
			listener.AuthenticationSchemes = 
				AuthenticationSchemes.Ntlm;
		}

	}

}