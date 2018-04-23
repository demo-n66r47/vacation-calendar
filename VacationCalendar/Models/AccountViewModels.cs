using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VacationCalendar.Properties;

namespace VacationCalendar.Models
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display( Name = nameof( Resources.Email ), ResourceType = typeof( Resources ) )]
		public string Email { get; set; }
	}

	public class ExternalLoginListViewModel
	{
		public string ReturnUrl { get; set; }
	}

	public class SendCodeViewModel
	{
		public string SelectedProvider { get; set; }
		public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
		public string ReturnUrl { get; set; }
		public bool RememberMe { get; set; }
	}

	public class VerifyCodeViewModel
	{
		[Required]
		public string Provider { get; set; }

		[Required]
		[Display( Name = "Code" )]
		public string Code { get; set; }
		public string ReturnUrl { get; set; }

		[Display( Name = "Remember this browser?" )]
		public bool RememberBrowser { get; set; }

		public bool RememberMe { get; set; }
	}

	public class ForgotViewModel
	{
		[Required]
		[Display( Name = nameof( Resources.Email ), ResourceType = typeof( Resources ) )]
		public string Email { get; set; }
	}

	public class LoginViewModel
	{
		[Required]
		[Display( Name = nameof( Resources.Email ), ResourceType = typeof( Resources ) )]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.Password ), ResourceType = typeof( Resources ) )]
		public string Password { get; set; }

		[Display( Name = nameof( Resources.RememberMe ), ResourceType = typeof( Resources ) )]
		public bool RememberMe { get; set; }
	}

	public class RegisterViewModel
	{
		[Required]
		[EmailAddress]
		[Display( Name = nameof( Resources.Email ), ResourceType = typeof( Resources ) )]
		public string Email { get; set; }

		[Required]
		[StringLength( 100, MinimumLength = 6, ErrorMessageResourceName = nameof( Resources.MinimumStringLength ), ErrorMessageResourceType = typeof( Resources ) )]
		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.Password ), ResourceType = typeof( Resources ) )]
		public string Password { get; set; }

		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.ConfirmPassword ), ResourceType = typeof( Resources ) )]
		[Compare( nameof( Password ), ErrorMessageResourceName = nameof( Resources.PasswordsDontMatch ), ErrorMessageResourceType = typeof( Resources ) )]
		public string ConfirmPassword { get; set; }
	}

	public class ResetPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display( Name = nameof( Resources.Email ), ResourceType = typeof( Resources ) )]
		public string Email { get; set; }

		[Required]
		[StringLength( 100, MinimumLength = 6, ErrorMessageResourceName = nameof( Resources.MinimumStringLength ), ErrorMessageResourceType = typeof( Resources ) )]
		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.Password ), ResourceType = typeof( Resources ) )]
		public string Password { get; set; }

		[DataType( DataType.Password )]
		[Display( Name = nameof( Resources.ConfirmPassword ), ResourceType = typeof( Resources ) )]
		[Compare( nameof( Password ), ErrorMessageResourceName = nameof( Resources.PasswordsDontMatch ), ErrorMessageResourceType = typeof( Resources ) )]
		public string ConfirmPassword { get; set; }

		public string Code { get; set; }
	}

	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display( Name = nameof( Resources.Email ), ResourceType = typeof( Resources ) )]
		public string Email { get; set; }
	}
}
