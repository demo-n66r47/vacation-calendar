using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace VacationCalendar
{
	public class LocalizationHelper
	{
		private static readonly List<string> _validCultures = CultureInfo.GetCultures( CultureTypes.AllCultures ).Select( x => x.Name ).ToList();
		private static readonly List<string> _cultures = new List<string>
		{
			"en",
			"hr",
		};
		public static readonly IEnumerable<CultureInfo> SupportedUICultures = _cultures.Select( x => new CultureInfo( x ) );

		public static string GetImplementedCulture(string name)
		{
			if ( string.IsNullOrEmpty( name ) )
				return GetDefaultCulture();

			if ( !_validCultures.Any( x => x.Equals( name, StringComparison.InvariantCultureIgnoreCase ) ) )
				return GetDefaultCulture();

			if ( _cultures.Any( x => x.Equals( name, StringComparison.InvariantCultureIgnoreCase ) ) )
				return name;

			var n = GetNeutralCulture( name );
			var c = _cultures.FirstOrDefault( x => x.StartsWith( n ) );
			return c ?? GetDefaultCulture();
		}

		public static string GetDefaultCulture() => _cultures[0];

		public static string GetNeutralCulture(string name) => new CultureInfo( name ).TwoLetterISOLanguageName;

	}
}