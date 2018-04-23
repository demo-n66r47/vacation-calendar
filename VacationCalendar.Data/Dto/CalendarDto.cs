using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationCalendar.Data.Properties;

namespace VacationCalendar.Data
{
	public class CalendarDto
	{
		public DateTime Date { get; set; }

		public int DaysInMonth => Convert.ToInt32( ( Date.Date.AddMonths( 1 ) - Date.Date ).TotalDays );

		public IEnumerable<CalendarEmployeeDto> Employees { get; set; }

	}

	public class CalendarEmployeeDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string FullName => $"{FirstName} {LastName}";

		public IEnumerable<CalendarDayDto> VacationDays { get; set; }
	}

	public class CalendarDayDto
	{
		public int Day { get; set; }

		[Display( Name = nameof( Resources.VacationType ), ResourceType = typeof( Resources ) )]
		public VacationTypeKind? VacationType { get; set; }

		public string VacationStyle => VacationType?.ToString().ToLowerInvariant();
	}
}
