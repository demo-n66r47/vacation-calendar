using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VacationCalendar.Data;

namespace VacationCalendar.Tests
{
	[TestClass]
	public class MappingTest
	{
		[TestMethod]
		public void TestAutoMapperConfiguration()
		{
			Mapper.Initialize( cfg => cfg.AddProfile<VacationCalendarProfile>() );
			Mapper.Configuration.AssertConfigurationIsValid();
		}
	}
}
