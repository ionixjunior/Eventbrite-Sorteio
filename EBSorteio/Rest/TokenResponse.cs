using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
	public class TokenResponse
	{
		[JsonProperty("access_token")]
		public string Token { get; set; }
	}
}

