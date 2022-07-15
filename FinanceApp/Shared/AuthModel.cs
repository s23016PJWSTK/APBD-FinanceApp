using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Shared
{
	public class LoginResult
	{
		public string message { get; set; }
        public string jwtBearer { get; set; }
		public bool success { get; set; }
	}
	public class LoginModel
	{
		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Email address is not valid.")]
		public string email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[DataType(DataType.Password)]
		public string password { get; set; }
	}

	public class RegModel : LoginModel
	{
		[Required(ErrorMessage = "Confirm password is required.")]
		[DataType(DataType.Password)]
		[Compare("password", ErrorMessage = "Password and confirm password do not match.")]
		public string confirmpwd { get; set; }
	}
}
