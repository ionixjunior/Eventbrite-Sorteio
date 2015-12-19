using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
	public class Attendee
	{
		[JsonProperty("profile")]
		public Profile Profile { get; set; }
	}
}

