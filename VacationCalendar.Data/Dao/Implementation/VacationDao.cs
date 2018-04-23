using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Data
{
	public class VacationDao : IVacationDao
	{
		private VacationCalendarDbContext _context;
		private IMapper _mapper;

		public VacationDao(VacationCalendarDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		public void Add(VacationDto dto)
		{
			Vacation vacation = _mapper.Map<Vacation>( dto );
			SetExistingEmployeeByName( vacation, dto );
			_context.Vacations.Add( vacation );
		}

		public void Edit(VacationDto dto)
		{
			Vacation vacation = _mapper.Map<Vacation>( dto );
			_context.Vacations.Attach( vacation );
			_context.Entry( vacation ).State = EntityState.Modified;

			if ( _context.Employees.Any( x => x.ID == dto.EmployeeID && ( x.FirstName != dto.EmployeeFirstName || x.LastName != dto.EmployeeLastName ) ) )
			{
				if ( SetExistingEmployeeByName( vacation, dto ) )
					DeleteEmployeeIfEmpty( dto );
				else
					_context.Entry( vacation.Employee ).State = EntityState.Modified;
			}
		}

		public void Remove(VacationDto dto)
		{
			if ( DeleteEmployeeIfEmpty( dto ) )
				return;

			Vacation vacation = new Vacation { ID = dto.ID, RowVersion = dto.RowVersion };
			_context.Vacations.Attach( vacation );
			_context.Entry( vacation ).State = EntityState.Deleted;
		}

		private bool SetExistingEmployeeByName(Vacation vacation, VacationDto dto)
		{
			Employee employee = _context.Employees.SingleOrDefault( x => x.ID != dto.EmployeeID && x.FirstName == dto.EmployeeFirstName && x.LastName == dto.EmployeeLastName );
			if ( employee == null )
				return false;

			_context.Entry( vacation.Employee ).State = EntityState.Detached;
			vacation.EmployeeID = employee.ID;
			vacation.Employee = employee;
			dto.EmployeeOwnerID = employee.OwnerID;
			return true;
		}

		private bool DeleteEmployeeIfEmpty(VacationDto dto)
		{
			if ( _context.Vacations.Any( x => x.EmployeeID == dto.EmployeeID && x.ID != dto.ID ) )
				return false;

			Employee employee = new Employee { ID = dto.EmployeeID, RowVersion = dto.EmployeeRowVersion };
			_context.Employees.Attach( employee );
			_context.Entry( employee ).State = EntityState.Deleted;
			return true;
		}


		public VacationDto GetById(int id) => GetByIdCore( id ).SingleOrDefault();

		public IEnumerable<VacationDto> GetAll() => GetAllCore().ToList();

		public void Save() => _context.SaveChanges();


		public async Task<VacationDto> GetByIdAsync(int id) => await GetByIdCore( id ).SingleOrDefaultAsync();

		public async Task<IEnumerable<VacationDto>> GetAllAsync() => await GetAllCore().ToListAsync();

		public async Task SaveAsync() => await _context.SaveChangesAsync();


		private IQueryable<VacationDto> GetByIdCore(int id) => GetQueryable().Where( x => x.ID == id );

		private IQueryable<VacationDto> GetAllCore()
		{
			return from x in GetQueryable()
					 orderby x.EmployeeFirstName, x.EmployeeLastName, x.DateFrom
					 select x;
		}

		private IQueryable<VacationDto> GetQueryable() => _context.Vacations.ProjectTo<VacationDto>( _mapper.ConfigurationProvider );

	}
}
