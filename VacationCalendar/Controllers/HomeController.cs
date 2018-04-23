using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VacationCalendar.Data;

namespace VacationCalendar.Controllers
{
	public class HomeController : BaseController
	{
		private ICalendarDao _calendarDao;

		public HomeController(ICalendarDao calendarDao, ILogger logger) : base( logger )
		{
			_calendarDao = calendarDao;
		}


		[AllowAnonymous]
		public async Task<ActionResult> Index(DateTime? date = null)
		{
			DateTime dt = date.GetValueOrDefault( DateTime.Today );
			return View( await _calendarDao.GetCalendarAsync( dt.Year, dt.Month ) );
		}

		[AllowAnonymous]
		public ActionResult SetLanguage(string culture, string returnUrl)
		{
			culture = LocalizationHelper.GetImplementedCulture( culture );
			HttpCookie cookie = Request.Cookies["_culture"];
			if ( cookie != null )
				cookie.Value = culture;
			else
			{
				cookie = new HttpCookie( "_culture" )
				{
					Value = culture,
					Expires = DateTime.Now.AddYears( 1 )
				};
			}
			Response.Cookies.Add( cookie );
			return Redirect( returnUrl );
		}

	}
}