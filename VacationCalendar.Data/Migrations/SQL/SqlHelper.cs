using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Data.Migrations
{
	public static class SqlHelper
	{
		public static string GetSql(string migrationName, bool up)
		{
			string direction = up ? "Up" : "Down";
			string name = $"VacationCalendar.Data.Migrations.SQL.{migrationName}{direction}.sql";
			using ( StreamReader reader = new StreamReader( Assembly.GetExecutingAssembly().GetManifestResourceStream( name ) ) )
				return reader.ReadToEnd();
		}

	}
}
