using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationCalendar.Data.Properties;

namespace VacationCalendar.Data
{
	public class VacationDto
	{
		[ScaffoldColumn( false )]
		public int EmployeeID { get; set; }

		[Display( Name = nameof( Resources.FirstName ), ResourceType = typeof( Resources ) )]
		[Required, StringLength( 50 )]
		public string EmployeeFirstName { get; set; }

		[Display( Name = nameof( Resources.LastName ), ResourceType = typeof( Resources ) )]
		[Required, StringLength( 50 )]
		public string EmployeeLastName { get; set; }

		[ScaffoldColumn( false )]
		public byte[] EmployeeRowVersion { get; set; }

		[ScaffoldColumn( false )]
		public string EmployeeOwnerID { get; set; }

		[ScaffoldColumn( false )]
		public int ID { get; set; }

		[Display( Name = nameof( Resources.DateFrom ), ResourceType = typeof( Resources ) )]
		[Required, DataType( DataType.Date ), DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true )]
		public DateTime? DateFrom { get; set; }

		[Display( Name = nameof( Resources.DateTo ), ResourceType = typeof( Resources ) )]
		[Required, DataType( DataType.Date ), DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true )]
		public DateTime? DateTo { get; set; }

		[Required, Display( Name = nameof( Resources.VacationType ), ResourceType = typeof( Resources ) )]
		public VacationTypeKind? VacationType { get; set; }

		[ScaffoldColumn( false )]
		public byte[] RowVersion { get; set; }
	}
}
