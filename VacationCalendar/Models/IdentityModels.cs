using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace VacationCalendar.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync( this, DefaultAuthenticationTypes.ApplicationCookie );
			// Add custom user claims here
			return userIdentity;
		}
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			 : base( "DefaultConnection", throwIfV1Schema: false )
		{
		}


		public static ApplicationDbContext Create() => new ApplicationDbContext();

	}

	public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			ApplicationRoleManager roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
			ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

			roleManager.GetOrCreateRole( IdentityHelper.RoleEmployee );

			var roleAdmin = roleManager.GetOrCreateRole( IdentityHelper.RoleAdmin );
			var userAdmin = userManager.FindByName( Properties.Settings.Default.AdminUserName );
			if ( userAdmin == null )
			{
				userAdmin = new ApplicationUser { UserName = Properties.Settings.Default.AdminUserName, Email = Properties.Settings.Default.AdminUserName };
				userManager.Create( userAdmin, Properties.Settings.Default.AdminPassword );
				userManager.SetLockoutEnabled( userAdmin.Id, false );
			}

			var rolesForUser = userManager.GetRoles( userAdmin.Id );
			if ( !rolesForUser.Contains( roleAdmin.Name ) )
				userManager.AddToRole( userAdmin.Id, roleAdmin.Name );
		}

	}
}