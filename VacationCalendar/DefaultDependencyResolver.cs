using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VacationCalendar
{
	public class DefaultDependencyResolver : IDependencyResolver
	{
		protected IServiceProvider serviceProvider;

		public DefaultDependencyResolver(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public object GetService(Type serviceType)
		{
			return this.serviceProvider.GetService( serviceType );
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this.serviceProvider.GetServices( serviceType );
		}
	}

	public static class ServiceProviderExtensions
	{
		public static IServiceCollection AddControllersAsServices(this IServiceCollection services, IEnumerable<Type> controllerTypes)
		{
			foreach ( var type in controllerTypes )
				services.AddTransient( type );

			return services;
		}
	}
}