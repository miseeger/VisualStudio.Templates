using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using AutofacModularity;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using $ext_safeprojectname$.Common.Interfaces.Services;
using NLog;

namespace $safeprojectname$
{

	[RegisterService]
	public class CrystalReportService: ICrystalReportService
	{

		private ILoggingService _logger;
		private string _reportPath;

		public string ReportPath
		{
			get
			{
				return _reportPath;
			}
			set
			{
				if (IsLoaded)
				{
					IsLoaded = _reportPath == value;
				}
				_reportPath = value;
			}
		}

		public string OutputPath { get; set; }
		public bool IsLoaded { get; private set; }
		public bool IsPrepared { get; private set; }
		public ReportDocument ReportDoc { get; set; }
		public string ConnectionString { get; set; }
		public string Filter { get; set; }
		public Dictionary<string, object> Parameters { get; set; }


		public CrystalReportService(ILoggingService loggingService, string reportPath, string reportOutputPath)
		{
			IsLoaded = false;
			IsPrepared = false;
			ReportDoc = new ReportDocument();
			Parameters = new Dictionary<string, object>();
			Filter = String.Empty;
			OutputPath = reportOutputPath;
			
			_reportPath = reportPath;
			_logger = loggingService;

			_logger.SetName("$safeprojectname$.CrystalReportService");
		}


		/// <summary>
		/// Gives access to all tables contained in the report and its sub reports.
		/// </summary>
		/// <param name="connInfo">Crystal Connection Infos</param>
		private void SetReportConnection(ConnectionInfo connInfo) 
		{
			foreach (Table tbl in ReportDoc.Database.Tables)
			{
				var logon = tbl.LogOnInfo; 
				logon.ConnectionInfo = connInfo; 
				tbl.ApplyLogOnInfo(logon); 
				tbl.Location = tbl.Location;
			} 
			
			if (!ReportDoc.IsSubreport)
			{ 
				foreach (ReportDocument subReport in ReportDoc.Subreports)
				{
					SetReportConnection(connInfo);
				}
			} 
		}


		/// <summary>
		/// Gibes access to the report tables (especially for Integrated Security).
		/// This method needs a native SQL ConnectionString.
		/// </summary>
		private void PrepareReportSecurity()
		{

			var conn = new SqlConnectionStringBuilder(ConnectionString);

			var connectionInfo = new ConnectionInfo()
			{
				Type = ConnectionInfoType.SQL,
				AllowCustomConnection = true,
				ServerName = conn.DataSource,
				DatabaseName = conn.InitialCatalog,
				UserID = conn.UserID,
				Password = conn.Password,
				IntegratedSecurity = conn.IntegratedSecurity
			};

			SetReportConnection(connectionInfo);
		}


		private void ApplyParameters()
		{
			if (Parameters.Count > 0)
			{
				foreach (ParameterField parameterField in ReportDoc.ParameterFields)
				{
					if (Parameters.ContainsKey(parameterField.Name)
						&& parameterField.ParameterType == ParameterType.ReportParameter)
					{
						object value;
						Parameters.TryGetValue(parameterField.Name, out value);
						parameterField.CurrentValues.Clear();
						parameterField.CurrentValues.AddValue(value);
					}
				}
			}
		}


		public void Load()
		{
			IsLoaded = false;

			if (File.Exists(ReportPath))
			{
				try
				{
					ReportDoc.Load(ReportPath);
					IsLoaded = true;
					_logger.Log(LogLevel.Info, String.Format("{0} was loaded.",ReportPath));
				}
				catch (Exception ex)
				{
					_logger.LogEx(String.Format("Error loading report {0}", ReportPath), ex);
				}
			}
			else
			{
				_logger.Log(LogLevel.Error, String.Format("Report {0} was not found.", ReportPath));
			}
		}


		public void Prepare()
		{
			if (IsLoaded)
			{
				IsPrepared = false;

				if (ConnectionString != String.Empty)
				{
					try
					{
						PrepareReportSecurity();
						ReportDoc.RecordSelectionFormula = Filter ?? String.Empty;
						ApplyParameters();
						IsPrepared = true;
						_logger.Log(LogLevel.Info, String.Format("{0} was prepared.",ReportPath));
					}
					catch (Exception ex)
					{
						_logger.LogEx(String.Format("Error while preparing the report (Method Prepare)"), ex);
					}
				}
				else
				{
					_logger.Log(LogLevel.Error,
						String.Format("The Connectionstring for report {0} was not given.", ReportPath));
				}
			}
			else
			{
				_logger.Log(LogLevel.Error,
					String.Format("Report {0} was not loaded. Preparation is not possible.", ReportPath));
			}
		}


		public void LoadAndPrepare()
		{
			Load();
			Prepare();
		}


		public void ToPdfFile()
		{
			if (IsLoaded && IsPrepared)
			{
				if (!Directory.Exists(OutputPath))
				{
					Directory.CreateDirectory(OutputPath);
				}

				var diskFileName = String.Format(@"{0}\{1}_{2:yyyyMMdd_HHmmss}.pdf", OutputPath,
					Path.GetFileNameWithoutExtension(ReportPath), DateTime.Now);

				var crExportOptions = new ExportOptions
				{
					ExportDestinationType = ExportDestinationType.DiskFile,
					ExportFormatType = ExportFormatType.PortableDocFormat,
					DestinationOptions = new DiskFileDestinationOptions
					{
						DiskFileName = diskFileName
					},
					FormatOptions = new PdfRtfWordFormatOptions()
				};

				try
				{
					ReportDoc.Export(crExportOptions);
				}
				catch (Exception ex)
				{
					_logger.LogEx(String.Format("Error exporting {0}", diskFileName), ex);
				}
			}
		}


		public Stream ToPdfStream()
		{
			if (IsLoaded && IsPrepared)
			{
				try
				{
					return ReportDoc.ExportToStream(ExportFormatType.PortableDocFormat);
				}
				catch (Exception ex)
				{
					_logger.LogEx(String.Format("Error while creating the FileStream for report {0}",ReportPath), ex);
				}
				_logger.Log(LogLevel.Info, String.Format("{0} was provided as FileStream.", ReportPath));
			}
			else
			{
				_logger.Log(LogLevel.Error, String.Format("Report {0} is {1}.", ReportPath,
					IsLoaded && !IsPrepared
						? "not prepared"
						: !IsLoaded && IsPrepared 
							? "not loaded" 
							: "neither loaded nor prepared"));
			}
			return null;
		}

	}

}