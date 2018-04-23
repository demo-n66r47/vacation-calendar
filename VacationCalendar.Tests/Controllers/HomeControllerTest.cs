using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VacationCalendar;
using VacationCalendar.Controllers;
using VacationCalendar.Data;

namespace VacationCalendar.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public async Task HomeIndex()
		{
			HomeController controller = DependencyResolver.Current.GetService<HomeController>();
			ViewResult result = await controller.Index( new DateTime( 2018, 4, 1 ) ) as ViewResult;
			CalendarDto model = result.Model as CalendarDto;
			Assert.IsNotNull( model );
		}

	}
}
