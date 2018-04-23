using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VacationCalendar.Data;

namespace VacationCalendar.Tests.Initialization
{
	[TestClass]
	public class Global
	{
		[AssemblyInitialize]
		public static void AssemblyInitialize(TestContext context)
		{
			AppDomain.CurrentDomain.SetData( "DataDirectory", AppDomain.CurrentDomain.BaseDirectory );
			Database.SetInitializer( new TestVacationDatabaseInitializer() );

			var services = new ServiceCollection();
			ConfigureServices( services );
			
			var resolver = new DefaultDependencyResolver( services.BuildServiceProvider() );
			DependencyResolver.SetResolver( resolver );

			VacationCalendarDbContext db = DependencyResolver.Current.GetService<VacationCalendarDbContext>();
			db.Database.Initialize( true );
		}

		private static void ConfigureServices(ServiceCollection services)
		{
			services.AddTransient( typeof( VacationCalendarDbContext ) );
			services.AddTransient( typeof( IVacationDao ), typeof( VacationDao ) );
			services.AddTransient( typeof( ICalendarDao ), typeof( CalendarDao ) );
			services.AddSingleton( typeof( ILogger ), typeof( MockLogger ) );

			var config = new MapperConfiguration( cfg => cfg.AddProfile<VacationCalendarProfile>() );
			services.AddSingleton( sp => config.CreateMapper() );
			
			services.AddControllersAsServices( typeof( Startup ).Assembly.GetExportedTypes()
				.Where( t => !t.IsAbstract && !t.IsGenericTypeDefinition )
				.Where( t => typeof( IController ).IsAssignableFrom( t ) || t.Name.EndsWith( "Controller", StringComparison.OrdinalIgnoreCase ) ) );
		}
	}
}
