using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationCalendar.Data.Model;

namespace VacationCalendar.Data
{
	public class VacationCalendarDbContext : DbContext
	{
		public VacationCalendarDbContext() : base( "VacationCalendarDbContext" )
		{
			Configuration.LazyLoadingEnabled = false;
		}


		public IEnumerable<GetCalendarResult> GetCalendar(int year, int month)
		{
			return GetCalendarCore( year, month ).ToList();
		}

		public async Task<IEnumerable<GetCalendarResult>> GetCalendarAsync(int year, int month)
		{
			return await GetCalendarCore( year, month ).ToListAsync();
		}

		private DbRawSqlQuery<GetCalendarResult> GetCalendarCore(int year, int month)
		{
			var yearParameter = new SqlParameter( "@year", year );
			var monthParameter = new SqlParameter( "@month", month );

			return Database.SqlQuery<GetCalendarResult>( "spGetCalendar @year, @month", yearParameter, monthParameter );
		}


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}


		public DbSet<Employee> Employees { get; set; }

		public DbSet<Vacation> Vacations { get; set; }

		public DbSet<Day> Days { get; set; }
	}
}
