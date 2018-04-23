using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VacationCalendar.Controllers
{
	public class ErrorPageController : BaseController
	{
		public ErrorPageController(ILogger logger) : base( logger )
		{

		}


		public ActionResult Error(int statusCode, Exception exception)
		{
			SetCulture();
			_logger.Error( exception, "Global error caught. Status code: {0}", statusCode );
			Response.StatusCode = statusCode;
			ViewBag.StatusCode = statusCode;
			return View();
		}
	}
}