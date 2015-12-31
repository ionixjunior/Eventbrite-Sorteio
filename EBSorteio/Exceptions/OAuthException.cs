using System;

namespace EBSorteio.Exceptions
{
	public class OAuthException : Exception
	{
		public OAuthException () : base ("Você precisa autenticar para carregar as informações.")
		{
		}
	}
}

