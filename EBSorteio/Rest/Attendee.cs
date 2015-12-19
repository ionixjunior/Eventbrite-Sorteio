using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
	public class Attendee
	{
		[JsonProperty("id")]
		public string ID { get; set; }

		[JsonProperty("profile")]
		public Profile Profile { get; set; }

		[JsonProperty("checked_in")]
		public bool Checked_in { get; set; }
	}
}

