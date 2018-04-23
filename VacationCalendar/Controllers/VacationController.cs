using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VacationCalendar.Data;
using VacationCalendar.Properties;

namespace VacationCalendar.Controllers
{
	public class VacationController : BaseController
	{
		private IVacationDao _vacationDao;

		public VacationController(IVacationDao vacationDao, ILogger logger) : base( logger )
		{
			_vacationDao = vacationDao;
		}


		[AllowAnonymous]
		public async Task<ActionResult> Index()
		{
			return View( await _vacationDao.GetAllAsync() );
		}

		[AllowAnonymous]
		public async Task<ActionResult> Details(int? id)
		{
			return await GetById( id, false );
		}

		public ActionResult Create()
		{
			if ( !User.IsEditAllowed() )
				return new HttpUnauthorizedResult();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(VacationDto dto)
		{
			try
			{
				if ( ModelState.IsValid )
				{
					dto.EmployeeOwnerID = User.GetUserId();
					_vacationDao.Add( dto );
					if ( User.IsEditAllowed( dto ) )
					{
						await _vacationDao.SaveAsync();
						return RedirectToAction( nameof( Index ) );
					}
					else
						ModelState.AddModelError( "", Resources.EditNotAllowed );
				}
			}
			catch ( Exception ex )
			{
				_logger.Error( ex, "Error in VacationController.Create" );
				ModelState.AddModelError( "", ex.GetInnerMessage() );
			}
			return View( dto );
		}

		public async Task<ActionResult> Edit(int? id)
		{
			return await GetById( id, true );
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(VacationDto dto)
		{
			try
			{
				if ( ModelState.IsValid )
				{
					_vacationDao.Edit( dto );
					if ( User.IsEditAllowed( dto ) )
					{
						await _vacationDao.SaveAsync();
						return RedirectToAction( nameof( Index ) );
					}
					else
						ModelState.AddModelError( "", Resources.EditNotAllowed );
				}
			}
			catch ( DbUpdateConcurrencyException dcex )
			{
				_logger.Error( dcex, "Error in VacationController.Edit(id={0})", dto.ID );
				ModelState.AddModelError( "", Resources.OptimisticConcurrencyError );
			}
			catch ( Exception ex )
			{
				_logger.Error( ex, "Error in VacationController.Edit(id={0})", dto.ID );
				ModelState.AddModelError( "", ex.GetInnerMessage() );
			}
			return View( dto );
		}

		public async Task<ActionResult> Delete(int? id)
		{
			return await GetById( id, true );
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(VacationDto dto)
		{
			try
			{
				_vacationDao.Remove( dto );
				await _vacationDao.SaveAsync();
				return RedirectToAction( nameof( Index ) );
			}
			catch ( DbUpdateConcurrencyException dcex )
			{
				_logger.Error( dcex, "Error in VacationController.Delete(id={0})", dto.ID );
				ModelState.AddModelError( "", Resources.OptimisticConcurrencyError );
			}
			catch ( Exception ex )
			{
				_logger.Error( ex, "Error in VacationController.Delete(id={0})", dto.ID );
				ModelState.AddModelError( "", ex.GetInnerMessage() );
			}
			return View( dto );
		}


		private async Task<ActionResult> GetById(int? id, bool checkEditAllowed)
		{
			if ( id == null )
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );

			VacationDto dto = await _vacationDao.GetByIdAsync( id.Value );
			if ( dto == null )
				return HttpNotFound();

			if ( checkEditAllowed && !User.IsEditAllowed( dto ) )
				return new HttpUnauthorizedResult();

			return View( dto );
		}

	}
}
