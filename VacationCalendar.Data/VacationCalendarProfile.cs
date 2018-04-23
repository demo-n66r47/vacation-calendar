using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Data
{
	public class VacationCalendarProfile : Profile
	{
		public VacationCalendarProfile()
		{
			CreateMap<Vacation, VacationDto>()
				.ReverseMap()
				.ForPath( s => s.Employee.ID, opt => opt.MapFrom( d => d.EmployeeID ) );
		}
	}
}
