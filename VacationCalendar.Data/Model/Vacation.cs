using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationCalendar.Data.Properties;

namespace VacationCalendar.Data
{
	public class Vacation
	{
		[Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public int ID { get; set; }

		[ForeignKey( "Employee" )]
		public int EmployeeID { get; set; }

		[Column( TypeName = "Date" )]
		public DateTime DateFrom { get; set; }

		[Column( TypeName = "Date" )]
		public DateTime DateTo { get; set; }

		public VacationTypeKind VacationType { get; set; }

		[Timestamp]
		public byte[] RowVersion { get; set; }

		public virtual Employee Employee { get; set; }
	}

	public enum VacationTypeKind : byte
	{
		[Display( Name = nameof( Resources.VacationTypeKind_VacationLeave ), ResourceType = typeof( Resources ) )]
		VacationLeave = 0,
		[Display( Name = nameof( Resources.VacationTypeKind_SickLeave ), ResourceType = typeof( Resources ) )]
		SickLeave = 1,
		[Display( Name = nameof( Resources.VacationTypeKind_Holiday ), ResourceType = typeof( Resources ) )]
		Holiday = 2,
	}
}
