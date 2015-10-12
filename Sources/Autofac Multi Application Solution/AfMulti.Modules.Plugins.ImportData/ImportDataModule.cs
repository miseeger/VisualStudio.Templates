using Autofac;
using AutofacModularity;
using AutofacModularity.Interfaces;

namespace $safeprojectname$
{

	public class ImportDataModule : ConfigurableModule
	{

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.RegisterType<ImportDataPlugin>().Named<IPlugin>("ImportDataPlugin");
		}

	}

}