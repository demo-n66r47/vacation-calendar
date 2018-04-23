using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Data
{
	public interface ICalendarDao
	{
		CalendarDto GetCalendar(int year, int month);
		Task<CalendarDto> GetCalendarAsync(int year, int month);
	}
}
