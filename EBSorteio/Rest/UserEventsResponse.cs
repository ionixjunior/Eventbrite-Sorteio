using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EBSorteio.Rest
{
	public class UserEventsResponse
	{
        [JsonProperty("events")]
        public List<Events> Events { get; set; }
	}
}

