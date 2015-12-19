using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
	public class Events
	{
		[JsonProperty("Name")]
        public Name Name { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
	}
}

