using System;
using System.Threading.Tasks;
using $ext_safeprojectname$.Common.Interfaces.Services;
using Microsoft.Owin;

namespace $safeprojectname$
{

	/// <summary>
	/// This is an example middleware which is only responsible for Requests
	/// addressed to pach "api/value". It checks if a the requesting user 
	/// is already authenticated by windows auth and if the user is active. 
	/// In this case the request will be logged and forwarded. Otherwise the
	/// request will be denied and an access violation is logged.
	/// </summary>
	public class AuthMiddleware : OwinMiddleware
	{

		private ILoggingService _logger;
		private IDbDataService _dbData;


		public AuthMiddleware(OwinMiddleware next, ILoggingService logger,
			IDbDataService dbData): base(next)
		{
			_logger = logger;
			_dbData = dbData;

			_logger.SetName("$safeprojectname$");
		}


		public override async Task Invoke(IOwinContext context)
		{
			if (!context.Request.Path.Value.ToLower().StartsWith("/api/value/"))
				await Next.Invoke(context);
			
			var currentWindowsUserLogin = context.Authentication.User.Identity.Name
				.Replace(@"Domain\", "").ToLower();
			var validUserList = _dbData.GetActiveUsers();

			if (validUserList.Contains(currentWindowsUserLogin))
			{
				_logger.Log(NLog.LogLevel.Info,
					String.Format("Request ({2}): {0} {1}", context.Request.Method,
						context.Request.Path, currentWindowsUserLogin));
			
				await Next.Invoke(context);
			}
			else
			{
				_logger.Log(NLog.LogLevel.Warn,
					String.Format("Access denied: {0} {1} - {2} ({3})",
						context.Request.Method, context.Request.Path,
						_dbData.CurrentUser, currentWindowsUserLogin));
			
				var response = context.Response;

				response.OnSendingHeaders(state =>
				{
					var resp = (OwinResponse) state;
					resp.StatusCode = 403;
					resp.ReasonPhrase = "Forbidden"; // You'll also have to change the ReasonPhrase.
				}, response);
			}
		}

	}

}