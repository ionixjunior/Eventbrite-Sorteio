using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
	public class Profile
	{
		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }
	}
}

