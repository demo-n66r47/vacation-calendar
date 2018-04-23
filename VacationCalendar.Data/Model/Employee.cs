using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Data
{
	public class Employee
	{
		[Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public int ID { get; set; }

		[Required, MaxLength( 50 ), Index( "UX_Employee_FirstLastName", 0, IsUnique = true )]
		public string FirstName { get; set; }

		[Required, MaxLength( 50 ), Index( "UX_Employee_FirstLastName", 1, IsUnique = true )]
		public string LastName { get; set; }

		[Timestamp]
		public byte[] RowVersion { get; set; }

		[MaxLength( 128 )]
		public string OwnerID { get; set; }

		public virtual IEnumerable<Vacation> Vacations { get; set; }
	}
}
