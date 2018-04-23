using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Data.Model
{
	public class GetCalendarResult
	{
		public int ID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int Day { get; set; }

		public VacationTypeKind? VacationType { get; set; }
	}
}
