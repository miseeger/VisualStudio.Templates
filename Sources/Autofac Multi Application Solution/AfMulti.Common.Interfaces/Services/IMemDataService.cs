using System;
using System.Collections.Generic;
using $ext_safeprojectname$.Common.Data.Model;
using $safeprojectname$;

namespace $safeprojectname$.Services
{

	public interface IMemDataService
	{

		List<StringValue> Data { get; set; }
		ILoggingService LoggingService { get; }

		void Hello();
		
	}

}