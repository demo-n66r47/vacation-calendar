using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using VacationCalendar.Data;
using VacationCalendar.Models;

[assembly: OwinStartupAttribute( typeof( VacationCalendar.Startup ) )]
namespace VacationCalendar
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var services = new ServiceCollection();
			ConfigureServices( services );

			var resolver = new DefaultDependencyResolver( services.BuildServiceProvider() );
			DependencyResolver.SetResolver( resolver );

			ConfigureAuth( app );

			DbInterception.Add( DependencyResolver.Current.GetService<VacationDbLoggingInterceptor>() );
			Database.SetInitializer( new ApplicationDbInitializer() );
		}

		private void ConfigureServices(ServiceCollection services)
		{
			services.AddTransient( typeof( VacationCalendarDbContext ) );
			services.AddTransient( typeof( IVacationDao ), typeof( VacationDao ) );
			services.AddTransient( typeof( ICalendarDao ), typeof( CalendarDao ) );

			services.AddSingleton( typeof( ILogger ), typeof( TraceLogger ) );
			services.AddSingleton( typeof( VacationDbLoggingInterceptor ) );

			var config = new MapperConfiguration( cfg => cfg.AddProfile<VacationCalendarProfile>() );
			services.AddSingleton( sp => config.CreateMapper() );
			
			services.AddControllersAsServices( typeof( Startup ).Assembly.GetExportedTypes()
				.Where( t => !t.IsAbstract && !t.IsGenericTypeDefinition )
				.Where( t => typeof( IController ).IsAssignableFrom( t ) || t.Name.EndsWith( "Controller", StringComparison.OrdinalIgnoreCase ) ) );
		}
	}
}
