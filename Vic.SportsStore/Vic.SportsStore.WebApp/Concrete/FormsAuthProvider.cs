using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vic.SportsStore.WebApp.Abstract;

namespace Vic.SportsStore.WebApp.Concrete
{
	public class FormsAuthProvider : IAuthProvider
	{
		public bool Authenticate(string username, string password)
		{
#pragma warning disable CS0618
			bool result = FormsAuthentication.Authenticate(username, password);
#pragma warning restore CS0618
			if (result)
			{
				FormsAuthentication.SetAuthCookie(username, false);
			}
			return result;
		}
	}
}