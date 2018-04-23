using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationCalendar.Data.Model;

namespace VacationCalendar.Data
{
	public class CalendarDao : ICalendarDao
	{
		private VacationCalendarDbContext _context;

		public CalendarDao(VacationCalendarDbContext context)
		{
			_context = context;
		}


		public CalendarDto GetCalendar(int year, int month)
		{
			var items = _context.GetCalendar( year, month );
			return GetCalendarFromList( year, month, items );
		}

		public async Task<CalendarDto> GetCalendarAsync(int year, int month)
		{
			var items = await _context.GetCalendarAsync( year, month );
			return GetCalendarFromList( year, month, items );
		}


		private CalendarDto GetCalendarFromList(int year, int month, IEnumerable<GetCalendarResult> items)
		{
			return new CalendarDto
			{
				Date = new DateTime( year, month, 1 ),
				Employees = items.GroupBy( x => new { x.FirstName, x.LastName } ).Select( employee => new CalendarEmployeeDto
				{
					FirstName = employee.Key.FirstName,
					LastName = employee.Key.LastName,
					VacationDays = employee.Select( date => new CalendarDayDto
					{
						Day = date.Day,
						VacationType = date.VacationType,
					} )
				} )
			};
		}

	}
}
