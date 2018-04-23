using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationCalendar
{
	public static class ExceptionHelper
	{
		public static string GetInnerMessage(this Exception ex)
		{
			while ( ex.InnerException != null )
				ex = ex.InnerException;
			return ex.Message;
		}

		public static int GetHttpErrorCode(this Exception ex) => ( ex as HttpException )?.GetHttpCode() ?? 500;

	}
}