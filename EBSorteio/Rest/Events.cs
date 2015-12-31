using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
	public class Events
	{
		[JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
	}
}

