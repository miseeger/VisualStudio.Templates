using System.Collections.Generic;

namespace $safeprojectname$.Services
{
	public interface IReportService
	{
		bool IsLoaded { get; }
		bool IsPrepared { get; }
		string ConnectionString { get; set; }
		string Filter { get; set; }
		Dictionary<string, object> Parameters { get; set; }
		string ReportPath { get; set; }
		string OutputPath { get; set; }
		void Load();
		void Prepare();
		void LoadAndPrepare();
		void ToPdfFile();
	}
}