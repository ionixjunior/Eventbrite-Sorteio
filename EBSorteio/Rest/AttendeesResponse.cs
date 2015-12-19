using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
	public class AttendeesResponse
	{
		[JsonProperty("attendees")]
		public List<Attendee> Attendees { get; set; }
	}
}

