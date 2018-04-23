using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationCalendar.Data;
using VacationCalendar.Data.Migrations;

namespace VacationCalendar.Tests.Initialization
{
	public class TestVacationDatabaseInitializer : DropCreateDatabaseAlways<VacationCalendarDbContext>
	{
		protected override void Seed(VacationCalendarDbContext context)
		{
			// ID 1
			Employee e1 = new Employee
			{
				FirstName = "First1",
				LastName = "Last1",
			};
			context.Employees.Add( e1 );

			// ID 2
			Employee e2 = new Employee
			{
				FirstName = "First2",
				LastName = "Last2",
			};
			context.Employees.Add( e2 );

			// ID 1
			context.Vacations.Add( new Vacation
			{
				Employee = e1,
				DateFrom = new DateTime( 2018, 4, 23 ),
				DateTo = new DateTime( 2018, 5, 2 ),
				VacationType = VacationTypeKind.VacationLeave,
			} );

			// ID 2
			context.Vacations.Add( new Vacation
			{
				Employee = e1,
				DateFrom = new DateTime( 2018, 5, 14 ),
				DateTo = new DateTime( 2018, 5, 16 ),
				VacationType = VacationTypeKind.SickLeave,
			} );

			// ID 3
			context.Vacations.Add( new Vacation
			{
				Employee = e1,
				DateFrom = new DateTime( 2018, 6, 18 ),
				DateTo = new DateTime( 2018, 6, 20 ),
				VacationType = VacationTypeKind.SickLeave,
			} );

			// ID 4
			context.Vacations.Add( new Vacation
			{
				Employee = e2,
				DateFrom = new DateTime( 2018, 5, 22 ),
				DateTo = new DateTime( 2018, 5, 24 ),
				VacationType = VacationTypeKind.Holiday,
			} );
		}
	}
}
