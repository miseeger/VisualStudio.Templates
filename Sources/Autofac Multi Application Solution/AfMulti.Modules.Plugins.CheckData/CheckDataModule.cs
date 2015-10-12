using Autofac;
using AutofacModularity;
using AutofacModularity.Interfaces;

namespace $safeprojectname$
{

	public class CheckDataModule : ConfigurableModule
	{

		public string Test { get; set; }


		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder
				.RegisterType<CheckDataPlugin>()
				.Named<IPlugin>("CheckDataPlugin")
				.WithParameter("test", Test);
		}

	}

}