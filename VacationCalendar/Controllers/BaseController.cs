using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace VacationCalendar.Controllers
{
	public abstract class BaseController : Controller
	{
		protected ILogger _logger;
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;

		public BaseController(ILogger logger)
		{
			_logger = logger;
		}


		protected void SetCulture()
		{
			string cultureName = Request.Cookies["_culture"]?.Value;
			cultureName = LocalizationHelper.GetImplementedCulture( cultureName );

			Thread.CurrentThread.CurrentCulture = new CultureInfo( cultureName );
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
		}

		protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
		{
			SetCulture();
			return base.BeginExecuteCore( callback, state );
		}

		protected override void OnException(ExceptionContext context)
		{
			_logger.Error( context.Exception, "Error in {0}", context.Controller.GetType() );
			context.ExceptionHandled = true;
			context.Result = new ViewResult
			{
				ViewName = "~/Views/Shared/Error.cshtml",
				ViewData = new ViewDataDictionary()
				{
					{ "statusCode", context.Exception.GetHttpErrorCode() },
				}
			};
		}

		protected override void Dispose(bool disposing)
		{
			if ( disposing )
			{
				if ( _userManager != null )
				{
					_userManager.Dispose();
					_userManager = null;
				}

				if ( _signInManager != null )
				{
					_signInManager.Dispose();
					_signInManager = null;
				}
			}

			base.Dispose( disposing );
		}


		public ApplicationSignInManager SignInManager
		{
			get
			{
				if ( _signInManager == null )
					_signInManager = HttpContext?.GetOwinContext()?.Get<ApplicationSignInManager>();
				return _signInManager;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				if ( _userManager == null )
					_userManager = HttpContext?.GetOwinContext()?.GetUserManager<ApplicationUserManager>();
				return _userManager;
			}
		}

	}
}