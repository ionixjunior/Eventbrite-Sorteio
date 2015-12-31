using System;
using EBSorteio.Common;

namespace EBSorteio
{
	public class AuthInfo
	{
		public static string Token
		{
			get { return (string) SessionManager.Get(SessionName.OAuthToken); }
		}
	}
}

