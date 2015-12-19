using System;
using Newtonsoft.Json;

namespace EBSorteio.Rest
{
    public class Name
    {
        [JsonProperty("text")]
        public String Text;

        [JsonProperty("html")]
        public String Html;
    }
}

