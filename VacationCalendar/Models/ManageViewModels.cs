using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using VacationCalendar.Properties;

namespace VacationCalendar.Models
{
	public class IndexViewModel
	{
		public bool HasPassword { get; set; }
		public IList<UserLoginInfo> Logins { get; set; }
		public string PhoneNumber { get; set; }
		public bool TwoFactor { get; set; }
		public bool BrowserRemembered { get; set; }
	}

	public class ManageLoginsViewModel
	{
		public IList<UserLoginInfo> CurrentLogins { get; set; }
		public IList<AuthenticationDescription> OtherLogins { get; set; }
	}

	public class FactorViewModel
	{
		public string Purpose { get; set; }
	}

	public class SetPasswordViewModel
	{
		[Required]
		[StringLength( 100, MinimumLength = 6, ErrorMessageResourceName = nameof( Resources.MinimumStringLength ), ErrorMessageResourceType = typeof( Resources ) )]
		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.NewPassword ), ResourceType = typeof( Resources ) )]
		public string NewPassword { get; set; }

		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.ConfirmPassword ), ResourceType = typeof( Resources ) )]
		[Compare( nameof( NewPassword ), ErrorMessageResourceName = nameof( Resources.PasswordsDontMatch ), ErrorMessageResourceType = typeof( Resources ) )]
		public string ConfirmPassword { get; set; }
	}

	public class ChangePasswordViewModel
	{
		[Required]
		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.OldPassword ), ResourceType = typeof( Resources ) )]
		public string OldPassword { get; set; }

		[Required]
		[StringLength( 100, MinimumLength = 6, ErrorMessageResourceName = nameof( Resources.MinimumStringLength ), ErrorMessageResourceType = typeof( Resources ) )]
		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.NewPassword ), ResourceType = typeof( Resources ) )]
		public string NewPassword { get; set; }

		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.ConfirmPassword ), ResourceType = typeof( Resources ) )]
		[Compare( nameof( NewPassword ), ErrorMessageResourceName = nameof( Resources.PasswordsDontMatch ), ErrorMessageResourceType = typeof( Resources ) )]
		public string ConfirmPassword { get; set; }
	}

	public class AddPhoneNumberViewModel
	{
		[Required]
		[Phone]
		[Display( Name = "Phone Number" )]
		public string Number { get; set; }
	}

	public class VerifyPhoneNumberViewModel
	{
		[Required]
		[Display( Name = "Code" )]
		public string Code { get; set; }

		[Required]
		[Phone]
		[Display( Name = "Phone Number" )]
		public string PhoneNumber { get; set; }
	}

	public class ConfigureTwoFactorViewModel
	{
		public string SelectedProvider { get; set; }
		public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
	}
}