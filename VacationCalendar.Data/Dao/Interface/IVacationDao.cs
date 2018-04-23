using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Data
{
	public interface IVacationDao
	{
		void Add(VacationDto dto);
		void Edit(VacationDto dto);
		void Remove(VacationDto dto);

		VacationDto GetById(int id);
		IEnumerable<VacationDto> GetAll();
		void Save();

		Task<VacationDto> GetByIdAsync(int id);
		Task<IEnumerable<VacationDto>> GetAllAsync();
		Task SaveAsync();
	}
}
