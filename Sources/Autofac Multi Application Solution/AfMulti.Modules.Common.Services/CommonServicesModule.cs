
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using AutofacModularity;
using EmailModule;


namespace $safeprojectname$
{

	/// <summary>
	/// AutoFac Module, which provides common services in Assembly 
	/// $ext_safeprojectname$.Common.Services.dll.
	/// </summary>
	public class CommonServicesModule : ConfigurableModule
	{

		public string DbActiveConnection { get; set; }
		public string Option { get; set; }
		public string ReportPath { get; set; }
		public string ReportOutputPath { get; set; }
		public string MailSmtpServerIp { get; set; }
		public string MailSmtpServerPort { get; set; }
		public string MailTemplatesDirectory { get; set; }
		public string MailDefaultFromAddress { get; set; }


		/// <summary>
		/// Loads common service assemblies and registers services in the DI Container.
	    /// Parameters defined in the app.config will be bound here.
		/// </summary>
		/// <param name="builder"></param>
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			// register common services
			builder.RegisterAssemblyTypes(Assembly.LoadFrom(@".\$ext_safeprojectname$.Common.Services.dll"))
				.Where(t => t.GetCustomAttributes(typeof (RegisterServiceAttribute), false).Any())
				.AsSelf()
				.AsImplementedInterfaces()
				.WithParameters(
					new[]
					{
						new NamedParameter("reportOutputPath", ReportOutputPath),
						new NamedParameter("reportPath", ReportPath),
						new NamedParameter("option", Option)
					})
				.SingleInstance();

			// Register common data services
			builder.RegisterAssemblyTypes(Assembly.LoadFrom(@".\$ext_safeprojectname$.Common.Data.dll"))
				.Where(t => t.GetCustomAttributes(typeof (RegisterServiceAttribute), false).Any())
				.AsSelf()
				.AsImplementedInterfaces()
				.WithParameters(
					new[]
					{
						new NamedParameter("dbActiveConnection", DbActiveConnection),
						new NamedParameter("option", Option)
					})
				.SingleInstance();

			// Register Mailzor E-Mail-Service
			builder.Register(c => new FileSystemEmailTemplateContentReader(MailTemplatesDirectory))
				.As<IEmailTemplateContentReader>();

			builder.RegisterType<EmailTemplateEngine>()
				.As<IEmailTemplateEngine>();

			builder.Register(
				c => new EmailSender
				{
					CreateClientFactory = () 
						=> new SmtpClientWrapper(new SmtpClient(MailSmtpServerIp, Convert.ToInt16(MailSmtpServerPort)))
					, DefaultFromAddress = MailDefaultFromAddress
				})
				.As<IEmailSender>();

			builder.Register(
				c => new EmailSubsystem(
					c.Resolve<IEmailTemplateEngine>(), 
					c.Resolve<IEmailSender>()))
				.As<IEmailSystem>()
				.SingleInstance();
		}

	}
}
