using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
	class Program
	{
		public static void Main(string[] args)
		{
			var bootstrapper = new ConsoleBootstrapper {Args = args};
			bootstrapper.Run(args);
		}
	}
}
