using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Data
{
	[Table( nameof( Day ), Schema = "Helper" )]
	public class Day
	{
		[Key, DatabaseGenerated( DatabaseGeneratedOption.None )]
		public int ID { get; set; }
	}
}
