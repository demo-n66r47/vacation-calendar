using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VacationCalendar.Controllers;
using VacationCalendar.Data;

namespace VacationCalendar.Tests.Controllers
{
	[TestClass]
	public class VacationControllerTest
	{
		[TestMethod]
		public async Task VacationIndex()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			ViewResult result = await controller.Index() as ViewResult;
			IEnumerable<VacationDto> model = result.Model as IEnumerable<VacationDto>;
			Assert.IsNotNull( model );
		}

		[TestMethod]
		public async Task VacationDetails()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			ViewResult result = await controller.Details( 1 ) as ViewResult;
			VacationDto model = result.Model as VacationDto;
			Assert.IsTrue( model.EmployeeID == 1 );
		}

		[TestMethod]
		public async Task VacationCreate()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			VacationDto dto = new VacationDto
			{
				EmployeeFirstName = "First3",
				EmployeeLastName = "Last3",
				DateFrom = new DateTime( 2018, 4, 23 ),
				DateTo = new DateTime( 2018, 4, 24 ),
				VacationType = VacationTypeKind.Holiday,
			};
			ActionResult result = await controller.Create( dto );
			Assert.IsTrue( result is RedirectToRouteResult );
		}

		[TestMethod]
		public async Task VacationCreateForExistingEmployee()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			VacationDto dto = new VacationDto
			{
				EmployeeFirstName = "First1",
				EmployeeLastName = "Last1",
				DateFrom = new DateTime( 2018, 6, 4 ),
				DateTo = new DateTime( 2018, 6, 7 ),
				VacationType = VacationTypeKind.VacationLeave,
			};
			ActionResult result = await controller.Create( dto );
			Assert.IsTrue( result is RedirectToRouteResult );
		}

		[TestMethod]
		public async Task VacationEdit()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			VacationDto model = await EditVacation( controller );

			model.DateTo = model.DateTo.Value.AddDays( 1 );
			ActionResult result = await controller.Edit( model );
			Assert.IsTrue( result is RedirectToRouteResult );
		}

		[TestMethod]
		public async Task VacationEditTestDateConstraint()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			VacationDto model = await EditVacation( controller );

			DateTime? dateFrom = model.DateFrom;
			model.DateFrom = model.DateTo;
			model.DateTo = dateFrom;
			ViewResult result = await controller.Edit( model ) as ViewResult;
			Assert.IsNotNull( result );
			Assert.IsFalse( controller.ModelState.IsValid );
		}

		[TestMethod]
		public async Task VacationEditTestDateTrigger()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			VacationDto model1 = await EditVacation( controller );
			VacationDto model2 = await EditVacation( controller, 2 );
			Assert.IsTrue( model1.EmployeeID == model2.EmployeeID );

			model2.DateFrom = model1.DateFrom;
			ViewResult result = await controller.Edit( model2 ) as ViewResult;
			Assert.IsNotNull( result );
			Assert.IsFalse( controller.ModelState.IsValid );
		}

		[TestMethod]
		public async Task VacationEditTestConcurrency()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			VacationDto model = await EditVacation( controller );
			model.DateTo = model.DateTo.Value.AddDays( 1 );
			ActionResult result1 = await controller.Edit( model );
			Assert.IsTrue( result1 is RedirectToRouteResult );

			ViewResult result2 = await controller.Edit( model ) as ViewResult;
			Assert.IsNotNull( result2 );
			Assert.IsFalse( controller.ModelState.IsValid );
		}

		[TestMethod]
		public async Task VacationDelete()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			ViewResult getResult = await controller.Delete( 3 ) as ViewResult;
			VacationDto model = getResult.Model as VacationDto;

			ActionResult postResult = await controller.Delete( model );
			Assert.IsTrue( postResult is RedirectToRouteResult );
		}

		[TestMethod]
		public async Task VacationEditMergeAndDelete()
		{
			VacationController controller = DependencyResolver.Current.GetService<VacationController>();
			VacationDto model = await EditVacation( controller, 4 );
			model.EmployeeFirstName = "First1";
			model.EmployeeLastName = "Last1";
			ActionResult result = await controller.Edit( model );
			Assert.IsTrue( result is RedirectToRouteResult );
		}


		private async Task<VacationDto> EditVacation(VacationController controller, int id = 1)
		{
			ViewResult result = await controller.Edit( id ) as ViewResult;
			return result.Model as VacationDto;
		}

	}
}
