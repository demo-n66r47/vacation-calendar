using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationCalendar.Tests
{
	public class MockLogger : ILogger
	{
		public void Error(string message) { }

		public void Error(string fmt, params object[] vars) { }

		public void Error(Exception exception, string fmt, params object[] vars) { }

		public void Information(string message) { }

		public void Information(string fmt, params object[] vars) { }

		public void Information(Exception exception, string fmt, params object[] vars) { }

		public void TraceApi(string componentName, string method, TimeSpan timespan) { }

		public void TraceApi(string componentName, string method, TimeSpan timespan, string properties) { }

		public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars) { }

		public void Warning(string message) { }

		public void Warning(string fmt, params object[] vars) { }

		public void Warning(Exception exception, string fmt, params object[] vars) { }
	}
}
