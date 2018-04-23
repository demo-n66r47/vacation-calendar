using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VacationCalendar.Controllers;

namespace VacationCalendar
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
			RouteConfig.RegisterRoutes( RouteTable.Routes );
			BundleConfig.RegisterBundles( BundleTable.Bundles );
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			Exception exception = Server.GetLastError();
			Server.ClearError();

			var routeData = new RouteData();
			routeData.Values.Add( "controller", "ErrorPage" );
			routeData.Values.Add( "action", "Error" );
			routeData.Values.Add( "statusCode", exception.GetHttpErrorCode() );

			Response.TrySkipIisCustomErrors = true;
			IController controller = DependencyResolver.Current.GetService<ErrorPageController>();
			controller.Execute( new RequestContext( new HttpContextWrapper( Context ), routeData ) );
			Response.End();
		}
	}
}
