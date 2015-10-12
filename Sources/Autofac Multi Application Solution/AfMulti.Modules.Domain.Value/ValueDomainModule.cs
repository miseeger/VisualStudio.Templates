using System;
using System.Linq;
using System.Reflection;
using Autofac;
using AutofacModularity;

namespace $safeprojectname$
{

	public class ValueDomainModule : ConfigurableModule
	{
		public string SpecialValue { get; set; }

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			// Domain logic for values
			builder.RegisterAssemblyTypes(Assembly.LoadFrom(@".\$ext_safeprojectname$.Domain.Value.dll"))
				.Where(t => t.GetCustomAttributes(typeof (RegisterServiceAttribute), false).Any())
				.WithParameter("specialValue", SpecialValue)
				.AsSelf()
				.AsImplementedInterfaces()
				.SingleInstance();
		}

	}

}
