using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
	public class Events
	{
		[JsonProperty("text")]
		public string Name { get; set; }
	}
}

