using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
    public class Name
    {
		[JsonProperty("text")]
		public string Event {get;set;}

        [JsonProperty("html")]
		public string Html { get; set; }

    }
}

