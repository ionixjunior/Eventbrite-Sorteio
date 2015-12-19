using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EBSorteio.Rest
{
	public class UserEvent
	{
		[JsonProperty("name")]
		public Events Events { get; set; }

	}
}

