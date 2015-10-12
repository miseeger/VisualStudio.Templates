using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace $safeprojectname$.Services
{
	public interface ICrystalReportService : IReportService
	{
		ReportDocument ReportDoc { get; set; }
		Stream ToPdfStream();
	}
}