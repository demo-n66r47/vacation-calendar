using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using VacationCalendar.Data;

namespace VacationCalendar
{
	public static class IdentityHelper
	{
		public const string RoleAdmin = "Admin";
		public const string RoleEmployee = "Employee";

		public static bool IsEditAllowed(this IPrincipal user, VacationDto dto = null) =>
			user == null || user.IsInRole( RoleAdmin ) ||
			( user.IsInRole( RoleEmployee ) &&
			( string.IsNullOrEmpty( dto?.EmployeeOwnerID ) || user.Identity.GetUserId() == dto.EmployeeOwnerID ) );

		public static string GetUserId(this IPrincipal user) => user?.Identity.GetUserId();

		public static IdentityRole GetOrCreateRole(this ApplicationRoleManager roleManager, string name)
		{
			var role = roleManager.FindByName( name );
			if ( role == null )
			{
				role = new IdentityRole( name );
				roleManager.Create( role );
			}
			return role;
		}

	}
}